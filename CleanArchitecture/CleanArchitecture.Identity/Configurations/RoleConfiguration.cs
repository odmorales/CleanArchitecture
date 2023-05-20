using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "b4668211-ac31-4bed-9370-adffe3314bf9",
                    Name= "Administrator",
                    NormalizedName= "ADMINISTRADOR",
                },
                new IdentityRole
                {
                    Id = "702490dc-62f0-4db4-a9ba-9ffd77706709",
                    Name = "Operator",
                    NormalizedName = "OPERATOR",
                }
            );
        }
    }
}
