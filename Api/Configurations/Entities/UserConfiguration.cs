using Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();
            builder.HasData(
                new ApiUser
                {
                    Id = "95194e5b-433f-42d4-8d41-74746f7f334b",
                    UserName = "admin@frenzyzone.com",
                    NormalizedUserName = "ADMIN@FRENZYZONE.COM",
                    Email = "admin@frenzyzone.com",
                    NormalizedEmail = "ADMIN@FRENZYZONE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Frenzy2022"),
                    SecurityStamp = string.Empty
                });

            
        }
    }
}
