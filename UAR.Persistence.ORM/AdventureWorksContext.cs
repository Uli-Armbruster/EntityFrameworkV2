 using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using UAR.Domain.AdventureWorks;

namespace UAR.Persistence.ORM
{
    internal class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
            : base("name=AdventureWorksContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}