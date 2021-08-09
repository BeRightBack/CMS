using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations.Entities
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(

                new Store
                {
                    Id = 1,
                    Name = "Indiana",
                    Url = "http://frenzyzone.com.Indiana"
                },
                new Store
                {
                    Id = 2,
                    Name = "AppleBee",
                    Url = "http://frenzyzone.com.AppleBee"
                },
                new Store
                {
                    Id = 3,
                    Name = "TechnoHub",
                    Url = "http://frenzyzone.com.TechnoHub"
                }
                );
        }
    }
}
