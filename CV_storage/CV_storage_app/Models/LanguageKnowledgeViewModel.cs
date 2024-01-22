using System.ComponentModel.DataAnnotations;
using CV_storage.Core.Enums;

namespace CV_storage_app.Models
{
    public class LanguageKnowledgeViewModel
    {
        public int Id { get; set; }
        [Required] public string? Language { get; set; }
        [Required] public KnowledgeLevel? LanguageLevel { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
