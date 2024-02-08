using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class Address : Entity
    {
        //recommended maximum length from microsoft page:
        // https://learn.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactaddress.country?view=winrt-22621
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
