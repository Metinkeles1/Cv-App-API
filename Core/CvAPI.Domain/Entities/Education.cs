using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class Education : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string SubTitle2 { get; set; }
        public string GPA { get; set; }
        public string Date { get; set; }
        public ICollection<EducationImageFile> EducationImageFiles { get; set; }
    }
}
