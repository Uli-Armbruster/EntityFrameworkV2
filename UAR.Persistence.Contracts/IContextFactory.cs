using System;

namespace UAR.Persistence.Contracts
{
    public interface IContextFactory
    {
        IDbContext Create();
    }
}