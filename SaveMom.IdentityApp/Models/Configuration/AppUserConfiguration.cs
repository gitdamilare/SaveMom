using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaveMom.IdentityApp.Models.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(SeedUserData());
        }

        private static List<AppUser> SeedUserData()
        {
            var fakeUsers = new Faker<AppUser>()
                .RuleFor(o => o.Email, o => o.Person.Email)
                .RuleFor(o => o.Email, o => o.Person.Email.ToUpper())
                .RuleFor(o => o.UserName, o => o.Person.Email)
                .RuleFor(o => o.NormalizedUserName, o => o.Person.Email.ToUpper())
                .RuleFor(o => o.FirstName, o => o.Person.FirstName)
                .RuleFor(o => o.LastName, o => o.Person.LastName)
                .RuleFor(o => o.EmailConfirmed, o => o.PickRandom(new bool[] { true, false }));

            var generatedFakeUsers = fakeUsers.Generate(5);
            
            var password = "Savemom2022@";
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            
            foreach (var user in generatedFakeUsers)
            {
                user.PasswordHash = ph.HashPassword(user, password);
            }

            return generatedFakeUsers;
        }
    }
}
