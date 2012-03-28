using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using UAR.Domain.Northwind;

namespace UAR.Persistence.ORM
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}