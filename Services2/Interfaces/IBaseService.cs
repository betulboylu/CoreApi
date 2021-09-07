using Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IBaseService<TEntity> where TEntity:class,IBase
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(int id, bool tracking = true);

        Task<TEntity> UpdateAsync(int id, TEntity updateEntity);

        Task DeleteAsync(int id);

        Task<List<TEntity>> GetAll();


    }
}
