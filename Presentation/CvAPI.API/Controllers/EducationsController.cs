
using CvAPI.Application.Repositories;
using CvAPI.Application.RequestParameters;
using CvAPI.Application.ViewModels.Educations;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {       
        private readonly IEducationReadRepository _educationReadRepository;
        private readonly IEducationWriteRepository _educationWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EducationsController(
            IEducationReadRepository educationReadRepository,
            IEducationWriteRepository educationWriteRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _educationReadRepository = educationReadRepository;
            _educationWriteRepository = educationWriteRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var totalCount = _educationReadRepository.GetAll(false).Count();
            var educations = _educationReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Title,
                p.SubTitle,
                p.SubTitle2,
                p.GPA,
                p.Date,
                p.CreatedDate,
                p.UpdatedDate
            });
            return Ok(new
            {
                totalCount,
                educations
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _educationReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vm_Create_Education model)
        {          
            await _educationWriteRepository.AddAsync(new()
            {
                Title = model.Title,
                SubTitle = model.SubTitle,
                SubTitle2 = model.SubTitle2,
                GPA = model.GPA,
                Date = model.Date,
            });
            await _educationWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vm_Update_Education model)
        {
            Education education = await _educationReadRepository.GetByIdAsync(model.Id);
            education.Title = model.Title;
            education.SubTitle = model.SubTitle;
            education.SubTitle2 = model.SubTitle2;
            education.GPA = model.GPA; 
            education.Date = model.Date;
            await _educationWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _educationWriteRepository.RemoveAsync(id);
            await _educationWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/education-images");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            Random r = new();

            foreach(IFormFile file in Request.Form.Files)
            {
                Guid guid = Guid.NewGuid();
                string noExtension = Path.GetFileNameWithoutExtension(file.FileName).ToLower()
                    .Replace(" ", "-").Replace("ğ", "g").Replace("ı", "i").Replace("ö", "o")
                    .Replace("ü", "u").Replace("ş", "s").Replace("ç", "c").Replace("Ç", "c")
                    .Replace("Ş", "s").Replace("Ğ", "g").Replace("Ü", "u").Replace("İ", "i")
                    .Replace("Ö", "o").Trim();


                string fullPath = Path.Combine(uploadPath, $"{noExtension + "-"}{guid}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }
    }
}
