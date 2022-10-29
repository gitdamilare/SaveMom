using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaveMom.IdentityApp.Models.Configuration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
            new AppRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                IsUserRole = false,
                Category = "Admin"
            },
            new AppRole
            {
                Name = "SubAdmin",
                NormalizedName = "SubAdmin",
                IsUserRole = false,
                Category = "Admin"
            },
            new AppRole
            {
                Name = "Doctor",
                NormalizedName = "Doctor",
                IsUserRole = true,
                Category = "User"
            },
            new AppRole
            {
                Name = "HealthCareProvider",
                NormalizedName = "Health Care Provider",
                IsUserRole = true,
                Category = "User"
            },
            new AppRole
            {
                Name = "Ministry ",
                NormalizedName = "Ministry",
                Category = "Manager",
                IsUserRole = true,
            });
        }
    }
}
