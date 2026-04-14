using System.Collections;
using Microsoft.EntityFrameworkCore;
using RepairShop.core;
using RepairShop.core.Repository.contrent;
using RepairShop.Repository.Genaric_Repository;

namespace RepairShop.Repository;

public class UnitOfWork:IUnitOfWork
{
    private readonly StoreContext _dbContext;
    private Hashtable _repositories;
    
    public UnitOfWork(StoreContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new Hashtable();
    }
    

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        var key= typeof(TEntity).Name;
        if (!_repositories.ContainsKey(key))
        {
            
            var repository=new GenericRepository<TEntity>(_dbContext);
            _repositories.Add(key, repository);
        }
        return _repositories[key] as IGenericRepository<TEntity>;
    }

    public async Task<int> CompleteAsync()
    => await _dbContext.SaveChangesAsync();
    
    public  async ValueTask DisposeAsync()
    =>await _dbContext.DisposeAsync();
}