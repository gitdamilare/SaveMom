using Bogus;
using MongoDB.Driver;
using SaveMom.Domain.Antenatal;

namespace SaveMom.Domain.SeedData
{
    public class MedicalHistorySeeder
    {
        public static void SeedData(
            IMongoCollection<MedicalHistory> medicalHistoryCollection,
            IMongoCollection<Patient> patientCollection,
            bool resetData = false)
        {
            var initialData = GetInitialData(patientCollection);
            if (!medicalHistoryCollection.Find(_ => true).Any())
            {
                medicalHistoryCollection.InsertOne(document: initialData);
            }
            else
            {
                if (resetData)
                {
                    medicalHistoryCollection.DeleteMany(_ => true);
                    medicalHistoryCollection.InsertOne(document: initialData);
                }
            }
        }

        private static MedicalHistory? GetInitialData(IMongoCollection<Patient> patientCollection)
        {
            #region MedicalHistory Data

            if (patientCollection.Find(_ => true).Any())
            {
                var patientIds = patientCollection.Find(_ => true).ToList().Select(p => p.Id).Take(3);
                var result = new[] { true, false };

                var medicalHistory = new Faker<MedicalHistory>()
                    .RuleFor(u => u.PatientId, o => o.PickRandom(patientIds))
                    .RuleFor(u => u.BabyLoss, o => o.PickRandom(result))
                    .RuleFor(u => u.SpontaneousAbortion, o => o.PickRandom(result))
                    .RuleFor(u => u.UnderWeightBaby, o => o.PickRandom(result))
                    .RuleFor(u => u.ExcessWeightBaby, o => o.PickRandom(result))
                    .RuleFor(u => u.LastPregnancy, o => o.PickRandom(result))
                    .RuleFor(u => u.PreviousSurgery, o => o.PickRandom(result))
                    .RuleFor(u => u.MultiplePregnancy, o => o.PickRandom(result))
                    .RuleFor(u => u.UnderAge, o => o.PickRandom(result))
                    .RuleFor(u => u.OverAge, o => o.PickRandom(result))
                    .RuleFor(u => u.RhesusNegative, o => o.PickRandom(result))
                    .RuleFor(u => u.VaginalBleeding, o => o.PickRandom(result))
                    .RuleFor(u => u.PelvicMass, o => o.PickRandom(result))
                    .RuleFor(u => u.DiastolicBP, o => o.PickRandom(result))
                    .RuleFor(u => u.DiabetesMellitus, o => o.PickRandom(result))
                    .RuleFor(u => u.RenalDisease, o => o.PickRandom(result))
                    .RuleFor(u => u.CardiacDisease, o => o.PickRandom(result))
                    .RuleFor(u => u.SickleCellDisease, o => o.PickRandom(result))
                    .RuleFor(u => u.HIVPositive, o => o.PickRandom(result))
                    .RuleFor(u => u.OtherMedicalCondition, o => o.Random.String2(10));

                return medicalHistory.Generate(1).FirstOrDefault();
            }

            return new ();
            #endregion
        }
    }
}
