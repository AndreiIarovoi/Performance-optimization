using System;
using System.Collections.Generic;
using System.Linq;

using StackOverflowSurvey.Domain.Dto;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Dto;
using StackOverflowSurvey.Service.Extensibility;
using StackOverflowSurvey.Service.SurveyImport;

using Respondent = StackOverflowSurvey.Service.Dto.Respondent;
using RespondentEntity = StackOverflowSurvey.Domain.Entities.Respondent;

namespace StackOverflowSurvey.Service
{
    public class RespondentsService : IRespondentsService
    {
        private readonly IRespondentsReader respondentsReader;

        private readonly IRespondentRepository respondentRepository;

        private readonly IRespondentsValidator respondentValidator;

        private readonly Func<ICompanySizeCache> companySizeCacheFactory;

        private readonly IExperienceLevelRepository experienceLevelRepository;

        public RespondentsService(
            IRespondentsReader respondentsReader,
            IRespondentRepository respondentRepository,
            IRespondentsValidator respondentValidator,
            Func<ICompanySizeCache> companySizeCacheFactory,
            IExperienceLevelRepository experienceLevelRepository)
        {
            this.respondentsReader = respondentsReader;
            this.respondentRepository = respondentRepository;
            this.respondentValidator = respondentValidator;
            this.companySizeCacheFactory = companySizeCacheFactory;
            this.experienceLevelRepository = experienceLevelRepository;
        }

        public IEnumerable<RespondentsCreationResult> CreateRespondents(IEnumerable<PostedFile> postedFiles)
        {
            foreach (PostedFile file in postedFiles)
            {
                IEnumerable<RespondentEntity> respondents = respondentsReader.ReadRespondents(file).ToList();
                IEnumerable<string> errors = respondentValidator.Validate(respondents);
                respondentRepository.AddRange(respondents);
                yield return new RespondentsCreationResult { FileName = file.FileName, Errors = errors };
            }
        }

        public IEnumerable<Respondent> GetRespondents(RespondentsFilter filter)
        {
            return respondentRepository.GetFiltered(CreateRespondentsQuery(filter)).ToList().Select(MapRespondent).Where(
                r => (string.IsNullOrEmpty(filter.ExperienceLevel) || r.ExperienceLevel.Contains(filter.ExperienceLevel))
                && (string.IsNullOrEmpty(filter.CompanySize) || r.CompanySize.Contains(filter.CompanySize)));
        }

        private RespondentsQuery CreateRespondentsQuery(RespondentsFilter filter)
        {
            return new RespondentsQuery
            {
                Professional = filter.Professional,
                Country = filter.Country,
                DeveloperType = filter.DeveloperType,
                Gender = filter.Gender,
                Language = filter.Language,
                VersionControl = filter.VersionControl
            };
        }

        private Respondent MapRespondent(RespondentEntity respondent)
        {
            Respondent newRespondent = new Respondent
                                 {
                                     Id = respondent.RespondentName,
                                     Country = respondent.Country,
                                     DeveloperType = respondent.EmploymentInfo.DeveloperType,
                                     Gender = respondent.Gender,
                                     Professional = respondent.Professional,
                                     CompanySize = companySizeCacheFactory().GetCompanyClass(respondent.EmploymentInfo.CompanySize),
                                     Language = respondent.HaveWorkedAndWantInfo.HaveWorkedLanguage,
                                     VersionControl = respondent.TechnicalDetailsInfo.VersionControl,
                                     WorkStart = respondent.Job.WorkStart,
                                     ExperienceLevel = experienceLevelRepository.GetAll().FirstOrDefault(e => e.YearsProgram == respondent.EmploymentInfo.YearsProgram)?.Level,
                                     CareerSatisfaction = respondent.EmploymentInfo.CareerSatisfaction,
                                     JobSatisfaction = respondent.EmploymentInfo.JobSatisfaction
                                 };
            return newRespondent;
        }
    }
}