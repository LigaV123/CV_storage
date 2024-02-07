using CV_storage.Core.Enums;

namespace CV_storage_app.Models
{
    public class GainedSkillViewModel
    {
        public int Id { get; set; }
        public string? Skill { get; set; }
        public TypeOfSkill SkillType { get; set; }
        public string? SkillDescription { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
