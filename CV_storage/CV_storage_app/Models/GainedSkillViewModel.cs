using CV_storage.Core.Enums;
using CV_storage.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CV_storage_app.Models
{
    public class GainedSkillViewModel
    {
        public int Id { get; set; }
        [Required] public string? Skill { get; set; }
        [Required] public TypeOfSkill? SkillType { get; set; }
        public string? SkillDescription { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
