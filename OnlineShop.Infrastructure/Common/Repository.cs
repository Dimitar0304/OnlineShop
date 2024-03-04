using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Common
{
    /// <summary>
    /// Repository class
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Dependecy injection database in class using private field and ctor
        /// </summary>
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Implementing method for add async entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>

        public async Task AddAsync<T>(T entity) where T : class
        {
            await GetSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// Implement adding range async 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await GetSet<T>().AddRangeAsync(entities);
        }

        /// <summary>
        /// Implement method for returns all for current type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> All<T>() where T : class
        {
            return GetSet<T>().AsQueryable<T>();
        }

        /// <summary>
        /// Implement all as readonly for current type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return GetSet<T>().AsNoTracking().AsQueryable<T>();
        }

        /// <summary>
        /// Method for delete current entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Delete<T>(T entity) where T : class
        {
            GetSet<T>().Remove(entity);
        }

        /// <summary>
        /// Implement delete async  by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync<T>(int id) where T : class
        {
            var entity = await GetByIdAsync<T>(id);
            await Delete<T>(entity);
        }

        /// <summary>
        /// Implement Delete range method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>

        public async Task DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            await DeleteRange<T>(entities);
        }

        /// <summary>
        /// Implement Get entity by identitfier async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            var entity = await GetSet<T>().FindAsync(id);
            if (entity != null)
            {

                return entity;
            }
            throw new ArgumentNullException(nameof(entity));
        }

        /// <summary>
        /// Implement save changes async
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Implement Update async method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync<T>(T entity) where T : class
        {
            GetSet<T>().Update(entity);

        }

        /// <summary>
        /// Implement update async in range method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            GetSet<T>().UpdateRange(entities);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Private getting sets method for get T set 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private DbSet<T> GetSet<T>() where T : class
        {
            return context.Set<T>();
        }
    }
}
