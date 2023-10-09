using Application.Repository;
using Domain.Interfaces;
using Persistence;
using Persistence.Data;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PassaportAuthContext _context;
    
    public UnitOfWork(PassaportAuthContext context)
    {
        _context = context;
    }
    
    private IComentario _comentarios;
    public IComentario Comentarios
    {
        get
        {
            if (_comentarios == null)
            {
                _comentarios = new ComentarioRepository(_context);
            }
            return _comentarios;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}