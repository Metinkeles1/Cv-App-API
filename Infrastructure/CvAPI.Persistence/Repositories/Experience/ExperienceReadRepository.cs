using CvAPI.Application.Repositories;
using CvAPI.Domain.Entities;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories
{
    public class ExperienceReadRepository : ReadRepository<Experience>, IExperienceReadRepository
    {
        public ExperienceReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}
