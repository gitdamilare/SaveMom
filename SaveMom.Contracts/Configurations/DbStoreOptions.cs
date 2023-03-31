
namespace SaveMom.Contracts.Configurations
{
    public class DbStoreOptions
    {
        public const string SectionName = "SaveMomStoreDatabase";

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string OrganisationCollectionName { get; set; } = string.Empty;

        public string AppRoleCollectionName { get; set; } = "AppRoles";

        public string AppUserCollectionName { get; set; } = "AppUsers";

        public string PatientCollectionName { get; set; } = "Patients";
    }
}
