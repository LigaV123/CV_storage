using CV_storage.Core.Services;
using CV_storage.Data;

namespace CV_storage.Services
{
    public class DeleteService : DbService, IDeleteService
    {
        public DeleteService(CvDbContext context) : base(context)
        {
        }

        public void DeleteEducationById(int id)
        {
            if(IdIsGreaterThanZero(id))
            {
                _context.Education.Remove(_context.Education.First(e => e.Id == id));
                _context.SaveChanges();
            }
        }

        public void DeleteSkillById(int id)
        {
            if (IdIsGreaterThanZero(id))
            {
                _context.GainedSkill.Remove(_context.GainedSkill.First(e => e.Id == id));
                _context.SaveChanges();
            }
        }

        public void DeleteJobById(int id)
        {
            if (IdIsGreaterThanZero(id))
            {
                _context.JobExperience.Remove(_context.JobExperience.First(e => e.Id == id));
                _context.SaveChanges();
            }
        }

        public void DeleteLanguageById(int id)
        {
            if (IdIsGreaterThanZero(id))
            {
                _context.LanguageKnowledge.Remove(_context.LanguageKnowledge.First(e => e.Id == id));
                _context.SaveChanges();
            }
        }

        public void DeleteCvById(int id)
        {
            if (IdIsGreaterThanZero(id))
            {
                _context.CurriculumVitae.Remove(_context.CurriculumVitae.First(e => e.Id == id));
                _context.SaveChanges();
            }
        }

        private bool IdIsGreaterThanZero(int id)
        {
            return id > 0;
        }
    }
}
