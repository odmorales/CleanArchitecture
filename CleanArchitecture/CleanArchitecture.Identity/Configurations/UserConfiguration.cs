
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "b5f298e7-3212-4bab-8e21-33c187fae316",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Oscar",
                    Apellidos = "Morales",
                    UserName = "odmorales",
                    NormalizedUserName = "odmorales",
                    PasswordHash = hasher.HashPassword(null, "04052000$"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "31c4d3b1-56c8-424d-9e31-0fc7b5fb6c78",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "JuanPerez",
                    NormalizedUserName = "JuanPerez",
                    PasswordHash = hasher.HashPassword(null, "04052000$"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
