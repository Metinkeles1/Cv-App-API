
using CvAPI.Application.Repositories;
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

        readonly private ISkillWriteRepository _ıSkillWriteRepository;
        readonly private ISkillReadRepository _skillReadRepository;
        public EducationsController(
            IEducationReadRepository educationReadRepository,
            IEducationWriteRepository educationWriteRepository,
            ISkillWriteRepository ıSkillWriteRepository,
            ISkillReadRepository skillReadRepository)
        {
            _educationReadRepository = educationReadRepository;
            _educationWriteRepository = educationWriteRepository;
            _ıSkillWriteRepository = ıSkillWriteRepository;
            _skillReadRepository = skillReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            Skill skill = await _skillReadRepository.GetByIdAsync("935a878a-e0d1-46bf-d40a-08db1edab3f5");
            skill.SkillName = "metin";
            await _ıSkillWriteRepository.SaveAsync();
        }     
    }
}
