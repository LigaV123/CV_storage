using CV_storage.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class JobExperience : Entity
    {
        [MaxLength(500)]
        public string? CompanyName { get; set; }

        [MaxLength(500)]
        public string? Position { get; set; }
        public WorkLoad? Workload { get; set; }

        [MaxLength(1875)] //approximate character count in one A4 page is 1875 chars
        public string? JobDescription { get; set; }

        [MaxLength(10)]
        public string? EmploymentStartDate { get; set; }

        [MaxLength(10)]
        public string? EmploymentEndDate { get; set; }


        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
