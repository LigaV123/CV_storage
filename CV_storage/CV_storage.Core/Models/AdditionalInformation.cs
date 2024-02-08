using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class AdditionalInformation : Entity
    {
        [MaxLength(1875)] //approximate character count in one A4 page is 1875 chars
        public string? AboutYou { get; set; }

        [MaxLength(1875)]
        public string? HobbiesAndInterests { get; set; }

        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
