using UAR.Persistence.Contracts;

namespace UAR.Persistence.ORM
{
    internal class ContextFactory : IContextFactory
    {
        public IDbContext Create()
        {
            return new WrappedContext(new AdventureWorksContext());
        }
    }
}