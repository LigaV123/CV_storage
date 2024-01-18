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
                cfg.CreateMap<CurriculumVitae, CvItemViewModel>()
                    .ForMember(d => d.LanguageKnowledge,
                        opt => opt.MapFrom(cv => cv.LanguageKnowledges))
                    .ForMember(d => d.Education, opt => opt.MapFrom(cv => cv.Educations));
                cfg.CreateMap<CvItemViewModel, CurriculumVitae>()
                    .ForMember(d => d.LanguageKnowledges,
                        opt => opt.MapFrom(cv => cv.LanguageKnowledge))
                    .ForMember(d => d.Educations, opt => opt.MapFrom(cv => cv.Education));

                cfg.CreateMap<LanguageKnowledge, LanguageKnowledgeViewModel>();
                cfg.CreateMap<LanguageKnowledgeViewModel, LanguageKnowledge>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());

                cfg.CreateMap<Education, EducationViewModel>();
                cfg.CreateMap<EducationViewModel, Education>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());

                cfg.CreateMap<Address, AddressViewModel>();
                cfg.CreateMap<AddressViewModel, Address>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());
            });

            #if DEBUG
            config.AssertConfigurationIsValid();
            #endif  

            return config.CreateMapper();
        }
    }
}
