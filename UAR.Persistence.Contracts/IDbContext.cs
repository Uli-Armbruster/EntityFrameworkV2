using System.Data.Entity;

namespace UAR.Persistence.Contracts
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        DbContext Context { get; }
    }
}