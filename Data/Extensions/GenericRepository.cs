using BasicWebApiFirstExam.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiFirstExam.Data.Extensions
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CompanyDbContext DbContext;

        protected readonly DbSet<T> DbSet;

        protected GenericRepository(CompanyDbContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {

            return await DbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}

