﻿
using CvAPI.Application.Repositories;
using CvAPI.Application.RequestParameters;
using CvAPI.Application.Services;
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
        private readonly IFileService _fileService;
        readonly IFileWriteRepository _fileWriteRepository;
        readonly IFileReadRepository _fileReadRepository;
        readonly IEducationImageWriteRepository _educationImageWriteRepository;
        readonly IEducationImageReadRepository _educationImageReadRepository;
        readonly IAboutMeImageFileWriteRepository _aboutMeImageFileWriteRepository;
        readonly IAboutMeImageFileReadRepository _aboutMeImageFileReadRepository;

        public EducationsController(
            IEducationReadRepository educationReadRepository,
            IEducationWriteRepository educationWriteRepository,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService,
            IFileWriteRepository fileWriteRepository,
            IFileReadRepository fileReadRepository,
            IEducationImageWriteRepository educationImageWriteRepository,
            IEducationImageReadRepository educationImageReadRepository,
            IAboutMeImageFileWriteRepository aboutMeImageFileWriteRepository,
            IAboutMeImageFileReadRepository aboutMeImageFileReadRepository)
        {
            _educationReadRepository = educationReadRepository;
            _educationWriteRepository = educationWriteRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _fileWriteRepository = fileWriteRepository;
            _fileReadRepository = fileReadRepository;
            _educationImageWriteRepository = educationImageWriteRepository;
            _educationImageReadRepository = educationImageReadRepository;
            _aboutMeImageFileWriteRepository = aboutMeImageFileWriteRepository;
            _aboutMeImageFileReadRepository = aboutMeImageFileReadRepository;
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
            var datas = await _fileService.UploadAsync("resource/files", Request.Form.Files);
            await _fileWriteRepository.AddRangeAsync(datas.Select(d => new CvAPI.Domain.Entities.File()
            {
                FileName = d.fileName,
                Path = d.path
            }).ToList());
            await _fileWriteRepository.SaveAsync();
            return Ok();

            //var datas = await _fileService.UploadAsync("resource/files", Request.Form.Files);
            //await _aboutMeImageFileWriteRepository.AddRangeAsync(datas.Select(d => new AboutmeImageFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path
            //}).ToList());
            //await _aboutMeImageFileWriteRepository.SaveAsync();
            //return Ok();

            //var datas = await _fileService.UploadAsync("resource/education-image", Request.Form.Files);
            //await _educationImageWriteRepository.AddRangeAsync(datas.Select(d => new EducationImageFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path,
            //    SchollImage = "Mersin"
            //}).ToList());
            //await _educationImageWriteRepository.SaveAsync();
            //return Ok();

            //var d1 = _fileReadRepository.GetAll(false);
            //var d2 = _aboutMeImageFileReadRepository.GetAll(false);
            //var d3 = _educationImageReadRepository.GetAll(false);            
        }
    }
}
