using GS.CodingChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GS.CodingChallenge.Application.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> Entities;

        public BaseRepository(DbContext context)
        {
            _context = context;
            Entities = context.Set<TEntity>();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            var entities = await Entities.ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await Entities.FindAsync(id);

            return entity;
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, string[] includeProperties = null,
            Func<TEntity, TEntity> select = null)
        {

            var query = Entities.Where(predicate);

            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return select != null ? query.Select(select) : query;
        }

        public async Task Add(TEntity entity)
        {
            Entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(int id)
        {
            var user = await GetById(id);
            Entities.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
