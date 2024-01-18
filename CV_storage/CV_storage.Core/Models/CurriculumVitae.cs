using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class CurriculumVitae : Entity
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(12)]
        public string? PhoneNumber { get; set; }

        public Address? MainAddress { get; set; } = new Address();

        public ICollection<LanguageKnowledge> LanguageKnowledges { get; set; }  = new List<LanguageKnowledge>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<JobExperience> JobExperiences { get; set; } = new List<JobExperience>();
        public ICollection<GainedSkill> GainedSkills { get; set; } = new List<GainedSkill>();
    }
}
