using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Newtonsoft.Json;
using System.Text.Json;
using Resources;

namespace CoreApi.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntity> : Controller where TEntity: class,IBase
    {
        protected readonly IBaseService<TEntity> service;

        protected readonly ILogger<BaseController<TEntity>> logger;

        /// <summary>
        /// Constructer
        /// </summary>
        /// <param name="serv"></param>
        /// <param name="_logger"></param>
        public BaseController([NotNull]IBaseService<TEntity> serv, ILogger<BaseController<TEntity>> _logger)
        {
            service = serv;
            logger = _logger;
        }

        /// <summary>
        /// CreateAsync: Creates a new entity based on the given entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns to corresponding entity</returns>
        [HttpPost]
        public async Task<IActionResult>CreateAsync(TEntity entity)
        { 
            entity = await service.CreateAsync(entity);
            logger.LogInformation(String.Format(ViewStrings.LogForCreate,entity.GetType()));
            return Ok(entity);
        }

        /// <summary>
        /// ReadAsync : Gets the corresponding entity based on the given entity Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns to corresponding entity</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult>ReadAsync(int id)
        {
            var entity = await service.ReadAsync(id);
            if (entity != null)
            {
                logger.LogInformation(String.Format(ViewStrings.LogForGet, entity.GetType(), id));
                return Ok(entity);
            }
            else
            {
                logger.LogError(String.Format(ViewStrings.LogForNotGet,service.GetType(), id));
                return NotFound();
            }
        }

        /// <summary>
        /// Returns all items
        /// </summary>
        /// <returns>Returns to corresponding entity list</returns>
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var entityList = await service.GetAll();
            logger.LogInformation(String.Format(ViewStrings.LogForGetAll, entityList.GetType()));
            return Ok(entityList);
        }

        /// <summary>
        /// UpdatePartialAsync : Updates the entity based on the given entity Id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchEntity"></param>
        /// <returns>Returns to updated entity</returns>
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdatePartialAsync(int id, [FromBody] JsonPatchDocument<TEntity> patchEntity)
        {
            var entity = await service.ReadAsync(id, false);

            if (entity == null)
            {
                logger.LogError(String.Format(ViewStrings.LogForNotUpdate, service.GetType(), id));
                return NotFound();
            }

            patchEntity.ApplyTo(entity,ModelState);
            entity = await service.UpdateAsync(id, entity);
            logger.LogInformation(String.Format(ViewStrings.LogForUpdate, entity.GetType(), id));
            return Ok(entity);
        }

        /// <summary>
        /// DeleteAsync : Updates IsDeleted field of the record based on the given entity Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns to deleted entity</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await service.ReadAsync(id);

            if (entity == null)
            {
                logger.LogError(String.Format(ViewStrings.LogForNotDelete, service.GetType(), id));
                return NotFound();
            }

            await service.DeleteAsync(id);
            logger.LogInformation(String.Format(ViewStrings.LogForDelete, entity.GetType(), id));
            return Ok(entity);
        }

      
    }
}