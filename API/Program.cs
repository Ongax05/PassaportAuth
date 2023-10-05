using Microsoft.EntityFrameworkCore;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//     try
//     {
//         var context = services.GetRequiredService<PassaportAuthContext>();
//         await context.Database.MigrateAsync();
//     }
//     catch (Exception ex)
//     {
//         var _logger = loggerFactory.CreateLogger<Program>();
//         _logger.LogError(ex, "Ocurrio un error durante la migracion");
//     }
// }


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
