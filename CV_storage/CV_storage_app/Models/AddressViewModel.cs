using System.ComponentModel.DataAnnotations;

namespace CV_storage_app.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        [Required] public string? Country { get; set; }
        public string? City { get; set; }
        [Required] public string? Region { get; set; }
        [Required] public string? StreetAddress { get; set; }
        [Required] public string? PostalCode { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
