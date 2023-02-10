
namespace LearningCenter.Data.IRepositories;

public interface IGenericRepository<T>
{
    Task<T> InsertAsync(T student);
    Task<T> UpdateAsync(int id, T student);
    Task<bool> DeleteAsync(int id);
    Task<T> SelectAsync(int id);
    Task<List<T>> SelectAllAsync(Func<T,bool> predicate);
}
