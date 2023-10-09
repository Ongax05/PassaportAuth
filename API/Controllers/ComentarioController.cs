using Application.UnitOfWork;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ComentarioController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ComentarioController(IUnitOfWork unitOfWork){
            _UnitOfWork = unitOfWork;
        }

        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(Comentario comentario){
            if (comentario == null){
                return BadRequest(400);
            }
            _UnitOfWork.Comentarios.Add(comentario);
            await _UnitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post),comentario);

        }
    }
}