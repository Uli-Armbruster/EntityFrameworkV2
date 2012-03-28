using System.Linq;

namespace UAR.Persistence.Contracts
{
    //Todo: Add AsNoTracking as Extension Method for IQuery
    public interface IQuery<out TResult,in TSource> where TSource : class
    {
        TResult Execute(IQueryable<TSource> entities);
    }
}