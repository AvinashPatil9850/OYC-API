using Microsoft.EntityFrameworkCore;
using OYC_API.Entities;
using OYC_API.Request;

namespace OYC_API.Data
{
    public class OycContext : DbContext
    {
        public OycContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<ProductSize> ProductSizeTable { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

}
