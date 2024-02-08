using CV_storage.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_storage.Data
{
    public class CvDbContext : DbContext, ICvDbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
        {}

        public DbSet<CurriculumVitae> CurriculumVitae { get; set; }
        public DbSet<LanguageKnowledge> LanguageKnowledge { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<JobExperience> JobExperience { get; set; }
        public DbSet<GainedSkill> GainedSkill { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AdditionalInformation> AdditionalInformation { get; set; }
    }
}
