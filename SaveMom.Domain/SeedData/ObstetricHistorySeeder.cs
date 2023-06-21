using Bogus;
using MongoDB.Driver;
using SaveMom.Domain.Antenatal;
using SaveMom.Domain.Prenatal;
using static SaveMom.Contracts.AppEnum;

namespace SaveMom.Domain.SeedData
{
    public class ObstetricHistorySeeder
    {
        public static void SeedData(
            IMongoCollection<ObstetricHistory> obstetricHistoryCollection,
            IMongoCollection<Patient> patientCollection,
            bool resetData = false)
        {
            if (!obstetricHistoryCollection.Find(_ => true).Any())
            {
                obstetricHistoryCollection.InsertMany(GetInitialData(patientCollection));
            }
            else
            {
                if (resetData)
                {
                    obstetricHistoryCollection.DeleteMany(_ => true);
                    obstetricHistoryCollection.InsertMany(GetInitialData(patientCollection));
                }
            }
        }

        private static List<ObstetricHistory>? GetInitialData(IMongoCollection<Patient> patientCollection)
        {
            #region ObstetricHistory Data

            if(patientCollection.Find(_ => true).Any())
            {
                var patientIds = patientCollection.Find(_ => true).ToList().Select(p => p.Id).Take(3);

                var obstetricHistory = new Faker<ObstetricHistory>()
                    .RuleFor(u => u.PatientId, o => o.PickRandom(patientIds))
                    .RuleFor(u => u.BirthYear, o => o.Person.DateOfBirth)
                    .RuleFor(u => u.Gender, o => o.PickRandomParam(new Gender[] { Gender.Male, Gender.Female }))
                    .RuleFor(u => u.Gestation, o => o.PickRandom(Enumerable.Range(0, 5)))
                    .RuleFor(u => u.LabourLength, o => o.PickRandom(Enumerable.Range(0, 5)))
                    .RuleFor(u => u.BirthPlace, o => o.Person.Address.City)
                    .RuleFor(u => u.BirthType, o => o.PickRandomParam(new BirthType[] { BirthType.CS, BirthType.SVD, BirthType.Assisted }))
                    .RuleFor(u => u.Comment, o => o.Random.String2(10));

                return obstetricHistory.Generate(2);
            }

            return new List<ObstetricHistory>();
            #endregion
        }
    }
}
