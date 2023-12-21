using CV_storage.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_storage.Data
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
        {

        }

        public DbSet<CurriculumVitae> CurriculumVitae { get; set; }
    }
}
