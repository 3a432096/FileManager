using Azure.Storage.Blobs;
using FileManager.Interface;
using Microsoft.Extensions.Configuration;

namespace FileManager.Services
{
    public class AzureService : IFileService
    {
        private readonly IConfiguration _configuration;
        private string _accountName;
        private string _accountKey;

        public AzureService(IConfiguration configuration)
        {
            _configuration = configuration;
            _accountName = _configuration["AzureStorageOptions:AccountName"];
            _accountKey = _configuration["AzureStorageOptions:AccountKey"];
        }

        public string GetFilePath()
        {
            throw new NotImplementedException();
        }

        public async Task UploadFile(IFormFile file)
        {
            // 建立 BlobServiceClient
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={_accountName};AccountKey={_accountKey};EndpointSuffix=core.windows.net";
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // 建立或取得容器
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("your-container-name");
            await containerClient.CreateIfNotExistsAsync();

            // 取得 BlobClient
            BlobClient blobClient = containerClient.GetBlobClient(file.FileName);

            // 開啟FileStream，上傳檔案，關閉FileStream
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }
        }

    }
}
