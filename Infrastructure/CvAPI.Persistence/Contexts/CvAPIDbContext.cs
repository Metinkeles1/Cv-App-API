﻿using CvAPI.Domain.Entities;
using CvAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Contexts
{
    public class CvAPIDbContext : DbContext
    {
        public CvAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Education> Educations{ get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<EducationImageFile> EducationImageFiles{ get; set; }
        public DbSet<AboutmeImageFile> AboutmeImageFiles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach(var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _=> DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
