using CvAPI.Application.Repositories;
using CvAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories
{
    public class FileReadRepository : ReadRepository<CvAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(CvAPIDbContext context) : base(context)
        {
        }
    }
}