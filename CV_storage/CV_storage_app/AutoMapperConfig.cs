using AutoMapper;
using CV_storage.Core.Models;
using CV_storage_app.Models;

namespace CV_storage_app
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CurriculumVitae, CvItemViewModel>();
                cfg.CreateMap<CvItemViewModel, CurriculumVitae>();

                cfg.CreateMap<LanguageKnowledge, LanguageKnowledgeViewModel>();
                cfg.CreateMap<LanguageKnowledgeViewModel, LanguageKnowledge>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());

                cfg.CreateMap<Education, EducationViewModel>();
                cfg.CreateMap<EducationViewModel, Education>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());

                cfg.CreateMap<Address, AddressViewModel>();
                cfg.CreateMap<AddressViewModel, Address>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());

                cfg.CreateMap<JobExperience, JobExperienceViewModel>();
                cfg.CreateMap<JobExperienceViewModel, JobExperience>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());

                cfg.CreateMap<GainedSkill, GainedSkillViewModel>();
                cfg.CreateMap<GainedSkillViewModel, GainedSkill>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());

                cfg.CreateMap<AdditionalInformation, AdditionalInformationViewModel>();
                cfg.CreateMap<AdditionalInformationViewModel, AdditionalInformation>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());
            });

            #if DEBUG
            config.AssertConfigurationIsValid();
            #endif  

            return config.CreateMapper();
        }
    }
}
