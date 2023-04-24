using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class EducationImageFile : File
    {
        public ICollection<Education> Educations { get; set; }
    }
}