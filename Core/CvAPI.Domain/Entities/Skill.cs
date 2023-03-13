using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class Skill:BaseEntity
    {
        public string SkillName { get; set; }
        public int Rate { get; set; }
    }
}
