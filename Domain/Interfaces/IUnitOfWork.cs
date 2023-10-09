using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IComentario Comentarios { get; }
        Task<int> SaveAsync();
    }
}