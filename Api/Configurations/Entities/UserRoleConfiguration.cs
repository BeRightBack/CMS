using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Configurations.Entities
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                builder.HasData(
                   
                    new IdentityUserRole<string>
                    {
                        RoleId = "95194e5b-433f-42d4-8d41-74746f7f334b",
                        UserId = "95194e5b-433f-42d4-8d41-74746f7f334b"
                    }

                );
            }
        }
}
