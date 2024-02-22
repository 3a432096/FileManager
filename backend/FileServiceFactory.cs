using FileManager.Enums;
using FileManager.Interface;
using FileManager.Services;
using System.Runtime.CompilerServices;

namespace FileManager
{
    public class FileServiceFactory
    {
        private readonly string _fileType;
        private readonly IConfiguration _configuration;

        public FileServiceFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _fileType = _configuration["FileServiceEnum"];
        }

        public IFileService CreateUploadService()
        {
            FileServiceEnum fileType = (FileServiceEnum)Enum.Parse(typeof(FileServiceEnum), _fileType,true);
            switch (fileType)
            {
                case FileServiceEnum.Local:
                    return new LocalService(_configuration);
                case FileServiceEnum.Azure:
                    return new AzureService(_configuration);
                case FileServiceEnum.GoogleDrive:
                    return new GoogleDriveService(_configuration);
                case FileServiceEnum.Redis:
                default:
                    throw new NotSupportedException($"File Serviece type '{fileType}' is not supported.");
            }
        }
    }
}
