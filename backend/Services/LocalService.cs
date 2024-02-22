using FileManager.Interface;

namespace FileManager.Services
{
    public class LocalService : IFileService
    {
        private string _folderPath;
        private readonly IConfiguration _configuration;

        public LocalService(IConfiguration configuration)
        {
            _configuration = configuration;
            var projectPath = Environment.CurrentDirectory;
            _folderPath = Path.Combine(projectPath, "wwwroot")  ;
        }

        public string GetFilePath()
        {
            return _folderPath;
        }

        public async Task UploadFile(IFormFile file)
        {
            // 檢查資料夾是否存在，如果不存在則創建它
            Directory.CreateDirectory(_folderPath);

            // 實現上傳至本地端的方法
            var filePath = Path.Combine(_folderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        }
    }
}
