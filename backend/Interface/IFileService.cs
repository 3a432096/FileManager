namespace FileManager.Interface
{
    public interface IFileService
    {
        string GetFilePath();
        Task UploadFile(IFormFile file);
    }
}
