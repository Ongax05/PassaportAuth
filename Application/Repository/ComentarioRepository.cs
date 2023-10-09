

using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ComentarioRepository : IComentario
{
    private readonly PassaportAuthContext _context;

    public ComentarioRepository(PassaportAuthContext context)
    {
        _context = context;
    }

    public virtual void Add(Comentario entity)
    {
        _context.Set<Comentario>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<Comentario> entities)
    {
        _context.Set<Comentario>().AddRange(entities);
    }

    public virtual IEnumerable<Comentario> Find(Expression<Func<Comentario, bool>> expression)
    {
        return _context.Set<Comentario>().Where(expression);
    }

    public virtual async Task<List<Comentario>> GetAllAsync()
    {
        return await _context.Set<Comentario>().ToListAsync();
        
    }

    public virtual async Task<Comentario> GetByIdAsync(int id)
    {
        return await _context.Set<Comentario>().FindAsync(id);
    }

    public virtual async Task<Comentario> GetByIdAsync(string id)
    {
       return await _context.Set<Comentario>().FindAsync(id);
    }

    public virtual void Remove(Comentario entity)
    {
        _context.Set<Comentario>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Comentario> entities)
    {
        _context.Set<Comentario>().RemoveRange(entities);
    }

    public virtual void Update(Comentario entity)
    {
        _context.Set<Comentario>()
            .Update(entity);
    }
}