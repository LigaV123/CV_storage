using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using CV_storage.Core.Models;

namespace CV_storage.Data
{
    public interface ICvDbContext
    {
        public DbSet<CurriculumVitae> CurriculumVitae { get; set; }
        public DbSet<LanguageKnowledge> LanguageKnowledge { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<JobExperience> JobExperience { get; set; }
        public DbSet<GainedSkill> GainedSkill { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AdditionalInformation> AdditionalInformation { get; set; }

        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
