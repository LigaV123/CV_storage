namespace CV_storage.Core.Services
{
    public interface IDeleteService : IDbService
    {
        void DeleteEducationById(int id);
        void DeleteSkillById(int id);
        void DeleteJobById(int id);
        void DeleteLanguageById(int id);
        void DeleteCvById(int id);
    }
}
