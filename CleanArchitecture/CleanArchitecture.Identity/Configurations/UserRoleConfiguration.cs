using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b4668211-ac31-4bed-9370-adffe3314bf9",
                    UserId = "b5f298e7-3212-4bab-8e21-33c187fae316"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "702490dc-62f0-4db4-a9ba-9ffd77706709",
                    UserId = "31c4d3b1-56c8-424d-9e31-0fc7b5fb6c78"
                }
            );
        }
    }
}
