using CV_storage.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class Education : Entity
    {
        [MaxLength(50)] public string? EducationalEstablishment { get; set; }
        [MaxLength(50)] public string? Faculty { get; set; }
        [MaxLength(50)] public string? Department { get; set; }
        public FormOfEducation EducationForm { get; set; }
        public DegreeInformation Degree { get; set; }
        public EducationStatus Status { get; set; }
        [MaxLength(10)] public string? EducationStartDate { get; set; }
        [MaxLength(10)] public string? EducationEndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
