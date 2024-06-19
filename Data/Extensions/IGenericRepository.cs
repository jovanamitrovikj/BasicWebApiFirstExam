namespace BasicWebApiFirstExam.Data.Extensions
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);

        Task<List<T>> GetAllAsync();

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);


        Task DeleteByIdAsync(object id);

    }
}
