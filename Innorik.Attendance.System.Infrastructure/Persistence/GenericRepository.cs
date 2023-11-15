using Innorik.Attendance.System.Application;
using Innorik.Attendance.System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innorik.Attendance.System.Infrastructure.Persistence
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(FormattableString sqlQuery)
        {
            var result = await _dbContext.Database.SqlQuery<int>(sqlQuery).ToListAsync();
            await _dbContext.SaveChangesAsync();
            return result.FirstOrDefault();
        } 
        
        public async Task<int> Adds(FormattableString sqlQuery)
        {
            var result = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAll(FormattableString sqlQuery)
        {
            List<TEntity> query = await _dbContext.Set<TEntity>().FromSqlInterpolated(sqlQuery).AsNoTracking().ToListAsync();
            if (query.Count == 0)
                return null;

            return query;
        }

        public async Task<TEntity> GetById(FormattableString sqlQuery)
        {
            List<TEntity> query = await _dbContext.Set<TEntity>().FromSqlInterpolated(sqlQuery).AsNoTracking().ToListAsync();
            return query.FirstOrDefault()!;
        }

        public async Task<int> Update(FormattableString sqlQuery)
        {
            var result = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
