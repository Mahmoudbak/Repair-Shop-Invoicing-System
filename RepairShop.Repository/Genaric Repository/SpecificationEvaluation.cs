using Microsoft.EntityFrameworkCore;
using RepairShop.core;
using RepairShop.core.Specifications;

namespace RepairShop.Repository.Genaric_Repository;

public class SpecificationEvaluation<TEntity>where TEntity:BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> Inputquery, Ispecifications<TEntity> Spec)
    {
        var query = Inputquery;//_dbcontext.Ticket
        
        
        if(Spec.criteria is not null)
            query=query.Where(Spec.criteria); //////query=_dbcontext.Products.Where(p=>p.Id==1)
     
        if(Spec.OrderBy is not null)
            query=query.OrderBy(Spec.OrderBy);
        else if(Spec.OrderByDesc is not null)
            query=query.OrderByDescending(Spec.OrderByDesc);
        
        
        if(Spec.IsPaginationEnabled)
            query=query.Skip(Spec.Skip).Take(Spec.Take);
        
        
        
        query=Spec.includes.Aggregate(query,(currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));
        return query;
    }
    
}