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

        private readonly ICompanySizeCache companySizeCache;

        private readonly IExperienceLevelCache experienceLevelCache;

        public RespondentsService(
            IRespondentsReader respondentsReader,
            IRespondentRepository respondentRepository,
            IRespondentsValidator respondentValidator,
            ICompanySizeCache companySizeCache,
            IExperienceLevelCache experienceLevelCache)
        {
            this.respondentsReader = respondentsReader;
            this.respondentRepository = respondentRepository;
            this.respondentValidator = respondentValidator;
            this.companySizeCache = companySizeCache;
            this.experienceLevelCache = experienceLevelCache;
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
            return respondentRepository.GetFiltered(CreateRespondentsQuery(filter)).Select(this.MapRespondent)
                .Where(r => (string.IsNullOrEmpty(filter.ExperienceLevel) || r.ExperienceLevel.Contains(filter.ExperienceLevel))
                        && (string.IsNullOrEmpty(filter.CompanySize) || r.CompanySize.Contains(filter.CompanySize))).AsEnumerable();
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

        private Respondent MapRespondent(RespondentInfo respondent)
        {
            Respondent newRespondent = new Respondent
            {
                Id = respondent.Id,
                Country = respondent.Country,
                DeveloperType = respondent.DeveloperType,
                Gender = respondent.Gender,
                Professional = respondent.Professional,
                CompanySize = this.companySizeCache.GetCompanySizesCache(respondent.CompanySize),
                Language = respondent.Language,
                VersionControl = respondent.VersionControl,
                WorkStart = respondent.WorkStart,
                ExperienceLevel = this.experienceLevelCache.GetExperienceLevelCache(respondent.ExperienceLevel),
                CareerSatisfaction = respondent.CareerSatisfaction,
                JobSatisfaction = respondent.JobSatisfaction
             };

            return newRespondent;
        }
    }
}