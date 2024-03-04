using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Common
{
    /// <summary>
    /// Repositoy interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Method for get all entities and can modify
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> All<T>() where T : class;
        /// <summary>
        /// Method for get all entities and can't modify for reading only
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> AllReadOnly<T>() where T : class;
        /// <summary>
        /// Method for get entity by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync<T>(int id) where T : class;
        /// <summary>
        /// Method for add entity
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <param name="entity">entity type</param>
        /// <returns></returns>
        public Task AddAsync<T>(T entity) where T : class;
        /// <summary>
        /// Method for adding range of entities
        /// </summary>
        /// <typeparam name="T">type parameter</typeparam>
        /// <param name="entities">collection of entities</param>
        /// <returns></returns>

        public Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
        /// <summary>
        /// Method for edit given entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">given entity</param>
        /// <returns></returns>
        public Task UpdateAsync<T>(T entity)where T : class;
        /// <summary>
        /// Method for edit collection of given entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">collection of given entities</param>
        /// <returns></returns>

        public Task UpdateRangeAsync<T>(IEnumerable<T> entities)where T : class;
        /// <summary>
        /// Method for delete entity by identifier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">entity identifier</param>
        /// <returns></returns>
        public Task DeleteAsync<T>(int id)where T : class;
        /// <summary>
        /// Method for delete entity by object of current entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Delete<T>(T entity) where T : class;
        /// <summary>
        /// Method for delete collection of current entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task DeleteRange<T>(IEnumerable<T> entities)where T: class;
        /// <summary>
        /// Method for save changes
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();

    }
}
