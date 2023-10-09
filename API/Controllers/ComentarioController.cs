using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("Comentario")]
    public class ComentarioController : Controller
    {
        private readonly IMapper _Mapper;
        private readonly IUnitOfWork _UnitOfWork;
        public ComentarioController(IUnitOfWork unitOfWork, IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<ComentarioDto>> Post([FromBody]ComentarioDto comentarioDto){
            Console.WriteLine($"\n\n\n{comentarioDto.Id + "    asdasdad   " + comentarioDto.Text}\n\n\n");
            var comentario = _Mapper.Map<Comentario>(comentarioDto);
            if (comentario == null){
                return BadRequest(400);
            }
            Console.WriteLine($"\n\n\n{comentario.Id + "    asdasdad   " + comentario.Text}\n\n\n");
            _UnitOfWork.Comentarios.Add(comentario);
            await _UnitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post),comentario);

        }
    }
}