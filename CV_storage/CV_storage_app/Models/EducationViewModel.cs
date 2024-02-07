using CV_storage.Core.Enums;

namespace CV_storage_app.Models
{
    public class EducationViewModel
    {
        public int Id { get; set; }
        public string? EducationalEstablishment { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }
        public FormOfEducation? EducationForm { get; set; }
        public DegreeInformation Degree { get; set; }
        public EducationStatus Status { get; set; }
        public string? EducationStartDate { get; set; }
        public string? EducationEndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
