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
    internal class ProductbrandConfigrations : IEntityTypeConfiguration<ProductBrand>

    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(b => b.Name).IsRequired();
        }
    }
}
