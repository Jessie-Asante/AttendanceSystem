namespace Innorik.Attendance.System.Infrastructure.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(FormattableString sqlQuery);
        Task<IEnumerable<TEntity>> GetAll(FormattableString sqlQuery);
        Task<int> Add(FormattableString sqlQuery);
        Task<int> Update(FormattableString sqlQuery);
    }
}