using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(

                 new Hotel
                 {
                     Id = 1,
                     Name = "Down Town Resort and Spa",
                     Address = "Mtl",
                     CountryId = 1,
                     Rating = 4.5
                 },
                 new Hotel
                 {
                     Id = 2,
                     Name = "Comfort Suites",
                     Address = "George Town",
                     CountryId = 2,
                     Rating = 4.3
                 },
                 new Hotel
                 {
                     Id = 3,
                     Name = "Grand Palldium",
                     Address = "Mexico City",
                     CountryId = 2,
                     Rating = 4
                 }
                 );
        }
    }
}
