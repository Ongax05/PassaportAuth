using Domain.Entities;
namespace Domain.Interfaces;
using System.Linq.Expressions;
public interface IComentario
{
    Task<Comentario> GetByIdAsync(string id);
    Task<List<Comentario>> GetAllAsync();
    IEnumerable<Comentario> Find(Expression<Func<Comentario, bool>> expression);
    void Add(Comentario entity);
    void AddRange(IEnumerable<Comentario> entities);
    void Remove(Comentario entity);
    void RemoveRange(IEnumerable<Comentario> entities);
    void Update(Comentario entity);
}