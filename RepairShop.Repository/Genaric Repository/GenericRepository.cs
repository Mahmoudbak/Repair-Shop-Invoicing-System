using Microsoft.EntityFrameworkCore;
using RepairShop.core;
using RepairShop.core.Repository.contrent;
using RepairShop.core.Specifications;

namespace RepairShop.Repository.Genaric_Repository;

public class GenericRepository<T>:IGenericRepository<T>where T:BaseEntity
{
    private readonly StoreContext _dbContext;
   

    public GenericRepository(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdWithSpecAsync(Ispecifications<T> Spec)
    {
       return await applySpecifiaction(Spec).FirstOrDefaultAsync();
    }

    
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispecifications<T> spec)
    {
        return await  applySpecifiaction(spec).ToListAsync(); 
    }

    public async Task<int> GetCountAsync(Ispecifications<T> spec)
    {
        return await applySpecifiaction(spec).CountAsync(); 
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await  _dbContext.Set<T>().FindAsync(id) ; 
    }
    //public async Task<T> GetEntityWithSpec(Ispecifications<T> spec)
    //{
    //    return await applySpecifiaction(spec).FirstOrDefaultAsync();

    //}


    private IQueryable<T> applySpecifiaction(Ispecifications<T> spec)
    {
        return SpecificationEvaluation<T>.GetQuery(_dbContext.Set<T>(), spec);
    }
    
    public async Task AddAsync(T entity)
    =>await _dbContext.Set<T>().AddAsync(entity);

    public void Update(T entity)
    =>_dbContext.Set<T>().Update(entity);

    public void Delete(T entity)
        => _dbContext.Set<T>().Remove(entity);
}