using CV_storage.Core.Models;
using CV_storage.Core.Services;
using CV_storage.Data;
using CV_storage.Services;
using CV_storage_app.Models;
using CV_storage_app.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace CV_storage_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddDbContext<CvDbContext>(options => 
                options.UseSqlite(builder.Configuration.GetConnectionString("cv-storage"))
            );
            var mapper = AutoMapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddScoped<IValidator<AddressViewModel>, AddressViewModelValidator>();
            builder.Services.AddScoped<IValidator<CvItemViewModel>, CvItemViewModelValidator>();
            builder.Services.AddScoped<IValidator<EducationViewModel>, EducationViewModelValidator>();
            builder.Services.AddScoped<IValidator<GainedSkillViewModel>, GainedSkillViewModelValidator>();
            builder.Services.AddScoped<IValidator<JobExperienceViewModel>, JobExperienceViewModelValidator>();
            builder.Services.AddScoped<IValidator<LanguageKnowledgeViewModel>, LanguageKnowledgeViewModelValidator>();

            builder.Services.AddSingleton<ICvValidations, DuplicateItemValidation>();

            builder.Services.AddTransient<ICvDbContext, CvDbContext>();
            builder.Services.AddTransient<IDbService, DbService>();

            builder.Services.AddTransient<IEntityService<CurriculumVitae>, EntityService<CurriculumVitae>>();
            builder.Services.AddTransient<IEntityService<LanguageKnowledge>, EntityService<LanguageKnowledge>>();
            builder.Services.AddTransient<IEntityService<Education>, EntityService<Education>>();
            builder.Services.AddTransient<IEntityService<Address>, EntityService<Address>>();
            builder.Services.AddTransient<IEntityService<JobExperience>, EntityService<JobExperience>>();
            builder.Services.AddTransient<IEntityService<GainedSkill>, EntityService<GainedSkill>>();
            builder.Services.AddTransient<IEntityService<AdditionalInformation>, EntityService<AdditionalInformation>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}