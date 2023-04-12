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
    public class EducationImageFileWriteRepository : WriteRepository<EducationImageFile>, IEducationImageWriteRepository
    {
        public EducationImageFileWriteRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}