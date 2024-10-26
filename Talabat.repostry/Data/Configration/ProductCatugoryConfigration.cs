using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Entities;

namespace Talabat.repostry.Data.Configration
{
    public class ProductCatugoryConfigration : IEntityTypeConfiguration<ProductCatugory>
    {
        public void Configure(EntityTypeBuilder<ProductCatugory> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
