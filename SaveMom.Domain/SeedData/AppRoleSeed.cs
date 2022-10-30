using MongoDB.Driver;
using SaveMom.Domain.Identity;

namespace SaveMom.Domain.SeedData
{
    internal class AppRoleSeed
    {
        public static void SeedData(IMongoCollection<AppRole> appRoleCollection)
        {
            if(!appRoleCollection.Find(_ => true).Any())
            {
                appRoleCollection.InsertMany(GetInitialData());
            }
        }

        private static IEnumerable<AppRole> GetInitialData()
        {
            return new List<AppRole>
            {
                new AppRole
            {
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                IsUserRole = false,
            },
                new AppRole
                {
                    Name = "SubAdmin",
                    NormalizedName = "SubAdmin".ToUpper(),
                    IsUserRole = false,
                },
                new AppRole
                {
                    Name = "Doctor",
                    NormalizedName = "Doctor".ToUpper(),
                    IsUserRole = true,
                },
                new AppRole
                {
                    Name = "HealthCareProvider",
                    NormalizedName = "Health Care Provider".ToUpper(),
                    IsUserRole = true,
                },
                new AppRole
                {
                    Name = "Ministry ",
                    NormalizedName = "Ministry".ToUpper(),
                    IsUserRole = true,
                }
            };
        }
    }
}
