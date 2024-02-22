using FileManager.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IConfiguration _configuration;

        public FileController(IFileService fileService, IConfiguration configuration)
        {
            _fileService = fileService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetFiles()
        {
            try
            {
                var filePath = _fileService.GetFilePath();

                // 獲取所有檔案
                var files = Directory.GetFiles(filePath);

                // 建立 URL 列表 // 您的後端服務的基礎 URL
                var baseUrl = _configuration["Sites:ApiUrl"];

                // 建立 URL 列表
                var urls = files.Select(file => $"{baseUrl}/{Path.GetFileName(file)}");

                // 回傳檔案列表
                return Ok(urls);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                //判斷是否有文件上傳
                if (file.Length ==0)
                {
                    return BadRequest("無檔案");
                }
            
                await _fileService.UploadFile(file);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
