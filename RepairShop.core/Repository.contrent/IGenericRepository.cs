using RepairShop.core.Specifications;

namespace RepairShop.core.Repository.contrent;

public interface IGenericRepository<T> where T :BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<T?>GetByIdWithSpecAsync(Ispecifications<T>Spec);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispecifications<T> spec);
    
    Task<int> GetCountAsync(Ispecifications<T> spec);
 
    //public IEnumerable<T> GetByDate(DateTime date);
    
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);  
    
}