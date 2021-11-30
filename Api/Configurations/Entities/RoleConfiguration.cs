using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Configurations.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "c6bb07ce-a39f-4ad0-b598-821b73034adc",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "95194e5b-433f-42d4-8d41-74746f7f334b",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
                   
            );
        }
    }
}
