using FileManager.Interface;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace FileManager.Services
{
    public class GoogleDriveService : IFileService
    {
        private readonly IConfiguration _configuration;
        private string _clientId;
        private string _clientSecret;

        public GoogleDriveService(IConfiguration configuration)
        {
            _configuration = configuration;
            _clientId = configuration["GoogleDriveOptions:ClientId"];
            _clientSecret = configuration["GoogleDriveOptions:ClientSecret"];
        }

        public string GetFilePath()
        {
            throw new NotImplementedException();
        }

        public async Task UploadFile(IFormFile file)
        {
            // 創建 Google Drive API 服務
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetCredentials(),
                ApplicationName = "Your Application Name",
            });

            // 創建新的檔案資源
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(file.FileName),
                MimeType = "application/octet-stream",
            };

            // 創建檔案上傳請求
            FilesResource.CreateMediaUpload request;

            using (var stream = new System.IO.MemoryStream())
            {
                await file.CopyToAsync(stream);
                request = service.Files.Create(
                    fileMetadata, stream, "application/octet-stream");
                request.Fields = "id";
                await request.UploadAsync();
            }
        }

        private UserCredential GetCredentials()
        {
            throw new Exception();
            // TODO: 實現獲取 Google API 憑證的邏輯
            // 你需要使用你的 _clientId 和 _clientSecret
            // 參考: https://developers.google.com/workspace/guides/create-credentials
        }
    }
}
