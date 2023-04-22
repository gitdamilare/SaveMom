using Bogus;
using MongoDB.Driver;
using SaveMom.Domain.Antenatal;
using static SaveMom.Contracts.Dtos.AppEnum;

namespace SaveMom.Domain.SeedData
{
    public static class PatientSeeder
    {
        public static void SeedData(IMongoCollection<Patient> patientCollection, bool resetdata = false)
        {
            if (!patientCollection.Find(_ => true).Any())
            {
                patientCollection.InsertMany(GetInitialData());
            }
            else
            {
                if (resetdata)
                {
                    patientCollection.DeleteMany(_ => true);
                    patientCollection.InsertMany(GetInitialData());
                }
            }


        }

        private static List<Patient> GetInitialData()
        {
            var fakeAddresses = new Faker<Address>()
                .RuleFor(o => o.Street, o => o.Address.StreetAddress())
                .RuleFor(o => o.City, o => o.Address.City())
                .RuleFor(o => o.LandMark, o => o.Address.SecondaryAddress())
                .RuleFor(o => o.Country, o => o.Address.Country());

            var fakeSpouseInfos = new Faker<ContactInfo>()
                .RuleFor(o => o.Name, o => o.Person.FullName)
                .RuleFor(o => o.EmailAddress, o => o.Internet.Email())
                .RuleFor(o => o.PhoneNumber, o => o.Person.Phone);

            #region Patient Data

            var fakePregnancyLoss = new Faker<PregnancyLoss>()
                .RuleFor(o => o.AbortionNo, o => o.PickRandom(Enumerable.Range(1, 5)))
                .RuleFor(o => o.EctopicNo, o => o.PickRandom(Enumerable.Range(1, 5)))
                .RuleFor(o => o.StillBirthNo, o => o.PickRandom(Enumerable.Range(1, 5)));

            var fakePregnancySummary = new Faker<PregnancySummary>()
                .RuleFor(o => o.LastMenstruationDate, o => DateTime.UtcNow)
                .RuleFor(o => o.ExpectedDeliveryDate, o => DateTime.UtcNow)
                .RuleFor(o => o.Gravida, o => o.PickRandom(Enumerable.Range(1, 5)))
                .RuleFor(o => o.Term, o => o.PickRandom(Enumerable.Range(1, 5)))
                .RuleFor(o => o.PerTerm, o => o.PickRandom(Enumerable.Range(1, 5)))
                .RuleFor(o => o.LivingNo, o => o.PickRandom(Enumerable.Range(1, 5)))
                .RuleFor(o => o.PregnancyLoss, o => fakePregnancyLoss.Generate(1).FirstOrDefault());

            var fakePatients = new Faker<Patient>()
                .RuleFor(o => o.FirstName, o => o.Person.FirstName)
                .RuleFor(o => o.LastName, o => o.Person.LastName)
                .RuleFor(o => o.DOB, o => o.Person.DateOfBirth)
                .RuleFor(u => u.HospitalPHCNO, u => Guid.NewGuid().ToString())
                .RuleFor(u => u.ContactNumber, f => f.Person.Phone)
                .RuleFor(u => u.Spouse, f => fakeSpouseInfos.Generate(1).FirstOrDefault())
                .RuleFor(u => u.Address, f => fakeAddresses.Generate(1).FirstOrDefault())
                .RuleFor(u => u.MaritalStatus, f => f.PickRandomParam(new MartialStatus[] { MartialStatus.Single, MartialStatus.Married, MartialStatus.Other }))
                .RuleFor(u => u.EducationLevel, f => f.PickRandomParam(new EducationLevel[] { EducationLevel.Primary, EducationLevel.Secondary, EducationLevel.Higher }))
                .RuleFor(u => u.Allergies, f => new string[] { "Wheezing", "Nausea", "Vomiting", "Diarrhea" })
                .RuleFor(u => u.CreatedBy, f => "ca2bb416-ed5e-43dc-b389-9fb85c0a6a0d")
                .RuleFor(u => u.ModifiedBy, f => "ca2bb416-ed5e-43dc-b389-9fb85c0a6a0d")
                .RuleFor(u => u.PregnancySummary, f => fakePregnancySummary.Generate(1).FirstOrDefault());

            #endregion

            return fakePatients.Generate(5);
        }
    }
}
