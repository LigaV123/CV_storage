using CV_storage.Core.Enums;

namespace CV_storage_app.Models
{
    public class LanguageKnowledgeViewModel
    {
        public int Id { get; set; }
        public string? Language { get; set; }
        public KnowledgeLevel LanguageLevel { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
