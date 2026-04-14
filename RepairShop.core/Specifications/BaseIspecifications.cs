using System.Linq.Expressions;

namespace RepairShop.core.Specifications;

public class BaseIspecifications<T>:Ispecifications<T>where T:BaseEntity
{
    public Expression<Func<T, bool>>? criteria { get; set; }
    public List<Expression<Func<T, object>>> includes { get; set; } = new List<Expression<Func<T, object>>>();
    public Expression<Func<T, object>> OrderBy { get; set; }
    public Expression<Func<T, object>> OrderByDesc { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public bool IsPaginationEnabled { get; set; }

    public BaseIspecifications()
    {
        
    }

    public BaseIspecifications(Expression<Func<T, bool>>? criteriaExpression )
    {
        criteria=criteriaExpression;
    }
    
    public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDesc = orderByDescExpression;
    }

    public void ApplyPagination(int skip, int take)
    {
        IsPaginationEnabled = true;
        Skip = skip;
        Take = take;
    }

}