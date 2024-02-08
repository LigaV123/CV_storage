using CV_storage.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class Education : Entity
    {
        [MaxLength(500)] 
        public string? EducationalEstablishment { get; set; }

        [MaxLength(500)] 
        public string? Faculty { get; set; }

        [MaxLength(500)] 
        public string? Department { get; set; }
        public StudyType? EducationForm { get; set; }
        public DegreeLevel Degree { get; set; }
        public EducationStatus Status { get; set; }

        [MaxLength(10)] 
        public string? EducationStartDate { get; set; }

        [MaxLength(10)] 
        public string? EducationEndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
