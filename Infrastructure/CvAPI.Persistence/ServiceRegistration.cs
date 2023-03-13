
using CvAPI.Application.Repositories;
using CvAPI.Persistence.Contexts;
using CvAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CvAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<IEducationReadRepository, EducationReadRepository>();
            services.AddScoped<IEducationWriteRepository, EducationWriteRepository>();
            services.AddScoped<IExperienceReadRepository, ExperienceReadRepository>();
            services.AddScoped<IExperienceWriteRepository, ExperienceWriteRepository>();
            services.AddScoped<ISkillReadRepository, SkillReadRepository>();
            services.AddScoped<ISkillWriteRepository, SkillWriteRepository>();
        }
    }
}
