namespace SaveMom.Contracts.Configurations
{
    public class AzureBlobStorageOptions
    {
        public const string SectionName = "AzureBS";

        public string? ConnectionString { get; set; }

        public string? VerificationContainerName { get; set; }
    }
}
