using System.ComponentModel.DataAnnotations;
using CV_storage.Core.Enums;

namespace CV_storage.Core.Models
{
    public class GainedSkill : Entity
    {
        [MaxLength(150)]
        public string? Skill { get; set; }
        public TypeOfSkill SkillType { get; set; }

        [MaxLength(1875)] //approximate character count in one A4 page is 1875 chars
        public string? SkillDescription { get; set; }

        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
