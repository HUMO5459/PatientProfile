using Microsoft.EntityFrameworkCore;
using PatientProfile.DbContext.Entity;
using PatientProfile.DbContext.Repositories.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatientProfile.DbContext.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PatientProfileDataContext _dbContext;

        public Repository(PatientProfileDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return await query.Where(w => w.Id == id).FirstOrDefaultAsync();
        }
        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return query;
        }

    }
}
