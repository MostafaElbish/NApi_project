using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Talabat.repostry.Data.Configration
{
    public class StoreDbcontext : DbContext
    {
        public StoreDbcontext(DbContextOptions<StoreDbcontext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(configuration: new ProductCatugoryConfigration());
            //modelBuilder.ApplyConfiguration(configuration: new ProductbrandConfigrations());
            //modelBuilder.ApplyConfiguration(configuration: new ProductConfigration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProsatcBrand { get; set; }
        public DbSet<ProductCatugory> ProducrCatugory { get; set; }

    } 
}
