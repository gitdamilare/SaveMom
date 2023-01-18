namespace SaveMom.Services
{
    public interface IAzureBlobService
    {
        Task<string> UploadFileToStorage(Stream fileStream, string fileName, string containerName);
    }
}
