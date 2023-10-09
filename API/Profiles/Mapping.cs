using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class Mapping : Profile
    {
        public Mapping (){
            CreateMap<Comentario, ComentarioDto>().ReverseMap();
        }
    }
}