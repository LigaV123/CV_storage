﻿using System.ComponentModel.DataAnnotations;

namespace CV_storage.Core.Models
{
    public class CurriculumVitae : Entity
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(12)]
        public string? PhoneNumber { get; set; }

        public ICollection<Address> MainAddress { get; set; } = new List<Address>();

        public ICollection<AdditionalInformation> AdditionalInformation { get; set; } = new List<AdditionalInformation>();

        public ICollection<LanguageKnowledge> LanguageKnowledge { get; set; }  = new List<LanguageKnowledge>();
        public ICollection<Education> Education { get; set; } = new List<Education>();
        public ICollection<JobExperience> JobExperience { get; set; } = new List<JobExperience>();
        public ICollection<GainedSkill> GainedSkill { get; set; } = new List<GainedSkill>();
    }
}
