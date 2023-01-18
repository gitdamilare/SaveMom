using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using SaveMom.Contracts.Configurations;

namespace SaveMom.Services
{
    public class AzureBlobServices : IAzureBlobService
    {
        private readonly AzureBlobStorageOptions _storageOptions;
        public AzureBlobServices(IOptions<AzureBlobStorageOptions> azureBlobStorageOptions)
        {
            _storageOptions = azureBlobStorageOptions.Value;
        }

        public async Task<string> UploadFileToStorage(Stream fileStream, string fileName, string containerName)
        {
            BlobContainerClient container = new BlobContainerClient(connectionString: _storageOptions.ConnectionString, blobContainerName: containerName);

            try
            {
                BlobClient blobClient = container.GetBlobClient(fileName);
                await blobClient.UploadAsync(fileStream);

                var fileUrl = blobClient.Uri.AbsoluteUri;
                return fileUrl;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
