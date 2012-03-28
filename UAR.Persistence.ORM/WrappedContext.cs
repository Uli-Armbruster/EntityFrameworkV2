using System.Data.Entity;

using UAR.Persistence.Contracts;

namespace UAR.Persistence.ORM
{
    internal class WrappedContext : IDbContext
    {
        readonly DbContext _context;

        public WrappedContext(DbContext context)
        {
            _context = context;
        }

        public IDbSet<T> Set<T>() where T:class
        {
            return _context.Set<T>();
        }

        public DbContext Context
        {
            get { return _context; }
        }
    }
}