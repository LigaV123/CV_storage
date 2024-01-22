using CV_storage.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CV_storage_app.Models
{
    public class EducationViewModel
    {
        public int Id { get; set; }
        [Required] public string? EducationalEstablishment { get; set; }
        [Required] public string? Faculty { get; set; }
        public string? Department { get; set; }
        public FormOfEducation? EducationForm { get; set; }
        [Required] public DegreeInformation? Degree { get; set; }
        [Required] public EducationStatus? Status { get; set; }
        [Required] public string? EducationStartDate { get; set; }
        public string? EducationEndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
