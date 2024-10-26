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
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(maxLength: 100);

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.PictureUrl)
                .IsRequired ();


            builder.HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.Category)
                .WithMany();

            
        }
    }
}
