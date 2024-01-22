using CV_storage.Core.Enums;
using CV_storage.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CV_storage_app.Models
{
    public class JobExperienceViewModel
    {
        public int Id { get; set; }
        [Required] public string? CompanyName { get; set; }
        [Required] public string? Position { get; set; }
        public AmountOfLabor? Workload { get; set; }
        [Required] public string? JobDescription { get; set; }
        [Required] public string? EmploymentStartDate { get; set; }
        public string? EmploymentEndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
