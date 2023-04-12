using CvAPI.Application.Repositories;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<CvAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}