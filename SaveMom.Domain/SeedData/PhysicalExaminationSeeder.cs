using System.Xml.Schema;
using Bogus;
using MongoDB.Driver;
using SaveMom.Domain.Antenatal;
using SaveMom.Domain.Prenatal;

namespace SaveMom.Domain.SeedData
{
    public static class PhysicalExaminationSeeder
    {
        public static void SeedData(IMongoCollection<PhysicalExamination> physicalExaminationCollection, IMongoCollection<Patient> patientCollection, bool resetData = false)
        {
            if (!physicalExaminationCollection.Find(_ => true).Any())
            {
                physicalExaminationCollection.InsertMany(GetInitialData(patientCollection));
            }
            else
            {
                if (resetData)
                {
                    physicalExaminationCollection.DeleteMany(_ => true);
                    physicalExaminationCollection.InsertMany(GetInitialData(patientCollection));
                }
            }
        }

        private static List<PhysicalExamination>? GetInitialData(IMongoCollection<Patient> patientCollection)
        {
            #region PhysicalExamination Data

            if (patientCollection.Find(_ => true).Any())
            {
                var patientIds = patientCollection.Find(_ => true).ToList().Select(p => p.Id).Take(3);
                var data = new[] { true, false };

                Func<Faker, Dictionary<string, bool>> testResult = (f) => new Dictionary<string, bool>()
                {
                    {"EntTest", f.PickRandom(data)},
                    {"NeurologicalTest", f.PickRandom(data)},
                    {"ThyroidTest", f.PickRandom(data)},
                    {"ExternalGenitaliaTest", f.PickRandom(data)},
                    {"ChestTest", f.PickRandom(data)},
                    {"CervixVaginaTest", f.PickRandom(data)},
                    {"BreastTest", f.PickRandom(data)},
                    {"UterusTest", f.PickRandom(data)},
                    {"CardiovascularTest", f.PickRandom(data)},
                    {"AdnexaText", f.PickRandom(data)},
                    {"AbdomenTest", f.PickRandom(data)},
                    {"VeinsLimbsTest", f.PickRandom(data)},
                };

                Func<Faker, Dictionary<string, bool>> healthTopicCovered = (f) =>  new Dictionary<string, bool>()
                {
                    {"Nutrition", f.PickRandom(data)},
                    {"RestExercise", f.PickRandom(data)},
                    {"SaferSexInPregnancy", f.PickRandom(data)},
                    {"MalariaInPregnancy", f.PickRandom(data)},
                    {"HivPmtct", f.PickRandom(data)},
                    {"BirthEmergencyReadiness", f.PickRandom(data)},
                    {"AlcoholDrug", f.PickRandom(data)},
                    {"FamilyPlanning", f.PickRandom(data)},
                    {"InfantFeeding", f.PickRandom(data)}
                };

                Func<Faker, List<LabTest>> labTest = (f) => new List<LabTest>()
                {
                    new()
                    {
                        Key = "BloodTest",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    },
                    new()
                    {
                        Key = "UrineProteinSugar",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    },
                    new()
                    {
                        Key = "SyphilisTest",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    },
                    new()
                    {
                        Key = "BloodGroupRhesusTest",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    },
                    new()
                    {
                        Key = "HIVTest",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    },
                    new()
                    {
                        Key = "UrineCulture",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    },
                    new()
                    {
                        Key = "HaemoglobinGenotype",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    },
                    new()
                    {
                        Key = "OtherTest",
                        Requested = f.PickRandom(data),
                        Result = f.Random.String2(10)
                    }
                };

                var physicalExaminations = new Faker<PhysicalExamination>()
                    .RuleFor(u => u.PatientId, o => o.PickRandom(patientIds))
                    .RuleFor(u => u.BloodPressure, o => o.Random.Int(min: 100, max:120))
                    .RuleFor(u => u.Weight, o => o.Random.Int(min: 50, max: 120))
                    .RuleFor(u => u.Pulse, o => o.Random.Int(min: 40, max: 90))
                    .RuleFor(u => u.PhysicalAbnormality, o => o.Random.String2(10))
                    .RuleFor(u => u.Comments, o => o.Random.String2(10))
                    .RuleFor(u => u.TestResult, o => testResult(o))
                    .RuleFor(u => u.HealthTopicCovered, o => healthTopicCovered(o))
                    .RuleFor(u => u.LabTest, o => labTest(o));

                return physicalExaminations.Generate(2);
            }

            return new List<PhysicalExamination>();
            #endregion
        }
    }
}
