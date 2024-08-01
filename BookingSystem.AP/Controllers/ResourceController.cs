using BookingSystem.DataModel.Master.Resource;
using BookingSystem.Master.Provider;
using DanCoffee.Web.Customer.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private MstResourceProvider ResProvider;
        private readonly IWebHostEnvironment _env;
        public ResourceController(MstResourceProvider resProvider, IWebHostEnvironment env)
        {
            ResProvider = resProvider;
            _env = env;
        }
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            try
            {
                var data = ResProvider.GetIndexBC(page);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var data = ResProvider.GetOne(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult CreateEdit(MstCreateEditResVM model)
        {
            try
            {
                string postFile = "resource";
                FileHandler(model,postFile);
                if (model.ID > 0)
                {
                    ResProvider.UpdateRes(model);
                }
                else
                {
                    ResProvider.InsertRes(model);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                ResProvider.DeleteRes(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("code")]
        public ActionResult DeleteResCode(int id)
        {
            try
            {
                ResProvider.DeleteResCod(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("images/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("Filename is not provided.");
            }

            var path = Path.Combine(_env.ContentRootPath, "Resource/image/resource", fileName);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var image = System.IO.File.OpenRead(path);
            return File(image, contentType);
        }

        private void FileHandler(MstCreateEditResVM dto,string url)
        {
            IFormFile multipartFile = dto.file;
            bool isMultipartEmpty = multipartFile == null || multipartFile.Length == 0;
            string icon = (string.IsNullOrEmpty(dto.Icon) && isMultipartEmpty) ? null : dto.Icon;

            try
            {
                if (!isMultipartEmpty)
                {
                    icon = FileHelper.UploadFile(icon, multipartFile, url);
                }

                dto.Icon = icon;
            }
            catch (Exception exception)
            {
            }
        }
    }
}
