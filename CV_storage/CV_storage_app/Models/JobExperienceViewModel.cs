using CV_storage.Core.Enums;

namespace CV_storage_app.Models
{
    public class JobExperienceViewModel
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public WorkLoad? Workload { get; set; }
        public string? JobDescription { get; set; }
        public string? EmploymentStartDate { get; set; }
        public string? EmploymentEndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
