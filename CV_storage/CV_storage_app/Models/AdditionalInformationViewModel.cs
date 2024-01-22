using System.ComponentModel.DataAnnotations;

namespace CV_storage_app.Models
{
    public class AdditionalInformationViewModel
    {
        public int Id { get; set; }
        public string? AboutYou { get; set; }
        public string? HobbiesAndInterests { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
