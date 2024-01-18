using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class Address : Entity
    {
        [MaxLength(1024)]
        public string? Country { get; set; }

        [MaxLength(1024)]
        public string? City { get; set; }

        [MaxLength(1024)]
        public string? Region { get; set; }

        [MaxLength(2048)]
        public string? StreetAddress { get; set; }

        [MaxLength(1024)]
        public string? PostalCode { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
