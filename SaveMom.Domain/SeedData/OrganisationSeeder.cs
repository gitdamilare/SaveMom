using Bogus;

namespace SaveMom.Domain.SeedData
{
    public static class OrganisationSeeder
    {
        public static List<Organisation> GetSeedData()
        {
            var fakeAddresses = new Faker<Address>()
                .RuleFor(o => o.Street, o => o.Address.StreetAddress())
                .RuleFor(o => o.City, o => o.Address.City())
                .RuleFor(o => o.LandMark, o => o.Address.SecondaryAddress())
                .RuleFor(o => o.Country, o => o.Address.Country());

            var fakeContactInfos = new Faker<ContactInfo>()
                .RuleFor(o => o.Name, o => o.Person.FullName)
                .RuleFor(o => o.EmailAddress, o => o.Internet.Email())
                .RuleFor(o => o.PhoneNumber, o => o.Person.Phone);

            var fakeOrganisations = new Faker<Organisation>()
                 .RuleFor(o => o.RegistrationNumber, o => o.Finance.Account())
                .RuleFor(u => u.Type, u => u.PickRandom<OrganisationType>())
                .RuleFor(u => u.Name, f => f.Company.CompanyName())
                .RuleFor(u => u.Address, f => fakeAddresses.Generate(1).FirstOrDefault())
                .RuleFor(u => u.ContactPerson, f => fakeContactInfos.Generate(1).FirstOrDefault())
                .RuleFor(u => u.IsActive, f => f.PickRandomParam(new bool[] { true, false }));

            return fakeOrganisations.Generate(1000);
        }
    }
}
