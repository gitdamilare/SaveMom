using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SaveMom.Contracts.Configurations;
using SaveMom.Domain.Antenatal;
using SaveMom.Domain.Identity;
using SaveMom.Domain.Prenatal;
using SaveMom.Domain.SeedData;

namespace SaveMom.Domain.Data
{
    public class MongoDbContext<T> : IDbContext<T> where T : class
    {
        public MongoDbContext(IConfiguration configuration)
        {
            var mongoDbSettings = configuration.GetSection(DbStoreOptions.SectionName).Get<DbStoreOptions>();
            var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
            Collection = mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");

            SeedApplicationData(mongoDatabase, mongoDbSettings);
        }
        public IMongoCollection<T> Collection { get; }


        private void SeedApplicationData(IMongoDatabase db, DbStoreOptions options)
        {
            var patientCN = db.GetCollection<Patient>(options.PatientCollectionName);

            AppRoleSeed.SeedData(db.GetCollection<AppRole>(options.AppRoleCollectionName));
            AppUserSeed.SeedData(db.GetCollection<AppUser>(options.AppUserCollectionName));
            PatientSeeder.SeedData(patientCN, resetdata: false);
            ObstetricHistorySeeder.SeedData(db.GetCollection<ObstetricHistory>(options.ObstetricHistoryCollectionName), patientCN, resetData: false);

            var medicalHistroyCN = db.GetCollection<MedicalHistory>(options.MedicalHistoryCollectionName);
            MedicalHistorySeeder.SeedData(medicalHistroyCN, patientCN);
        }
    }
}
