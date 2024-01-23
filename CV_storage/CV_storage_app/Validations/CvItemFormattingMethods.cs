using CV_storage_app.Models;

namespace CV_storage_app.Validations
{
    public class CvItemFormattingMethods
    {
        public static string Languages(List<LanguageKnowledgeViewModel> model)
        {
            return ConcatenateItems(model, l => l.Language);
        }

        public static string Educations(List<EducationViewModel> model)
        {
            return ConcatenateItems(model, e => e.Faculty);
        }

        public static string Skills(List<GainedSkillViewModel> model)
        {
            return ConcatenateItems(model, s => s.Skill);
        }

        public static string Jobs(List<JobExperienceViewModel> model)
        {
            return ConcatenateItems(model, j => j.Position);
        }

        private static string ConcatenateItems<T>(List<T> model, Func<T, string> propertySelector)
        {
            var distinctValues = model.Select(propertySelector).Distinct().ToList();
            string result = string.Join(", ", distinctValues);

            return result;
        }
    }
}
