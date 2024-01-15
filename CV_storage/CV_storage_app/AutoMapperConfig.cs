using AutoMapper;
using CV_storage.Core.Models;
using CV_storage_app.Models;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System.Configuration;

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
                        opt => opt.MapFrom(cv => cv.LanguageKnowledges));
                cfg.CreateMap<CvItemViewModel, CurriculumVitae>()
                    .ForMember(d => d.LanguageKnowledges,
                        opt => opt.MapFrom(cv => cv.LanguageKnowledge));
                cfg.CreateMap<LanguageKnowledge, LanguageKnowledgeViewModel>();
                cfg.CreateMap<LanguageKnowledgeViewModel, LanguageKnowledge>()
                    .ForMember(d => d.CurriculumVitae, opt => opt.Ignore());
            });

            #if DEBUG
            config.AssertConfigurationIsValid();
            #endif  

            return config.CreateMapper();
        }
    }
}
