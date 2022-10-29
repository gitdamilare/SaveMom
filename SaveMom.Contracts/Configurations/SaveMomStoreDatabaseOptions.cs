
namespace SaveMom.Contracts.Configurations
{
    public class SaveMomStoreDatabaseOptions
    {
        public const string SectionName = "SaveMomStoreDatabase";

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string OrganisationCollectionName { get; set; } = string.Empty;
    }
}
