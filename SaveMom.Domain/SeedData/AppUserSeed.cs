
using Bogus;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using SaveMom.Domain.Identity;

namespace SaveMom.Domain.SeedData
{
    internal class AppUserSeed
    {
        public static void SeedData(IMongoCollection<AppUser> appUserCollection)
        {
            if (!appUserCollection.Find(_ => true).Any())
            {
                appUserCollection.InsertMany(GetInitialData());
            }
        }


        private static IEnumerable<AppUser> GetInitialData()
        {
            var fakeUsers = new Faker<AppUser>()
                .RuleFor(o => o.Email, o => o.Person.Email)
                .RuleFor(o => o.NormalizedEmail, o => o.Person.Email.ToUpper())
                .RuleFor(o => o.UserName, o => o.Person.Email)
                .RuleFor(o => o.NormalizedUserName, o => o.Person.Email.ToUpper())
                .RuleFor(o => o.FirstName, o => o.Person.FirstName)
                .RuleFor(o => o.LastName, o => o.Person.LastName)
                .RuleFor(o => o.PhoneNumber, o => o.Person.Phone)
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
