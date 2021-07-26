using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                 new Product
                 {
                     Id = 1,
                     Name = "Down Town Resort and Spa",
                     ShortDescription = "short description",
                     FullDescription = "Full description",
                     Price = 100.00,
                     StoreId = 1
                 },
                 new Product
                 {
                     Id = 2,
                     Name = "Comfort Suites",
                     ShortDescription = "short description",
                     FullDescription = "Full description",
                     Price = 10.00,
                     StoreId = 2
                 },
                 new Product
                 {
                     Id = 3,
                     Name = "Grand Palldium",
                     ShortDescription = "short description",
                     FullDescription = "Full description",
                     Price = 1.00,
                     StoreId = 3
                 }
                 );
        }
    }
}
