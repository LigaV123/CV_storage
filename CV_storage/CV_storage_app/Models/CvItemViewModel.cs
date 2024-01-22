using CV_storage.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CV_storage_app.Models
{
    public class CvItemViewModel
    {
        public int Id { get; set; }
        [Required] public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required] public string? LastName { get; set; }
        [Required] public string? Email { get; set; }
        [Required] public string? PhoneNumber { get; set; }

        public List<AddressViewModel> MainAddress { get; set; } = new List<AddressViewModel>();
        public List<AdditionalInformationViewModel> AdditionalInformation { get; set; } = new List<AdditionalInformationViewModel>();
        public List<LanguageKnowledgeViewModel> LanguageKnowledge { get; set; } = new List<LanguageKnowledgeViewModel>();
        public List<EducationViewModel> Education { get; set; } = new List<EducationViewModel>();
        public List<JobExperienceViewModel> JobExperience { get; set; } = new List<JobExperienceViewModel>();
        public List<GainedSkillViewModel> GainedSkill { get; set; } = new List<GainedSkillViewModel>();
    }
}
