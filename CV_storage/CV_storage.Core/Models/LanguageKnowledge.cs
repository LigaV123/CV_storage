using System.ComponentModel.DataAnnotations;
using CV_storage.Core.Enums;

namespace CV_storage.Core.Models
{
    public class LanguageKnowledge : Entity
    {
        [MaxLength(30)]
        public string? Language { get; set; }
        public KnowledgeLevel? LanguageLevel { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
