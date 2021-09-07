using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Services
{
    public abstract class BaseService<TEntity>:IBaseService<TEntity> where TEntity:class, IBase
    {
        protected WebApiDbContext dbContext;

        protected BaseService([NotNull]WebApiDbContext CoreApiDbContext)
        {
           dbContext =CoreApiDbContext ; 
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> ReadAsync(int id, bool tracking=true)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            if(!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(entity => entity.Id == id && !entity.IsDeleted.HasValue);               
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>().AsQueryable();
            return query.ToListAsync();
        }

        public virtual async Task<TEntity>UpdateAsync(int id, TEntity entity)
        {
            var uEntity = await ReadAsync(id);
            dbContext.Entry(uEntity).CurrentValues.SetValues(entity);
            dbContext.Entry(uEntity).State = EntityState.Modified;

            if (dbContext.Entry(uEntity).Properties.Any(property => property.IsModified))
                await dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await ReadAsync(id);
            entity.IsDeleted = DateTimeOffset.Now;
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

        }


    }
}
