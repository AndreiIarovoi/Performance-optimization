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

        private readonly ICompanySizeRepository companySizeRepository;

        private readonly IExperienceLevelRepository experienceLevelRepository;

        public RespondentsService(
            IRespondentsReader respondentsReader,
            IRespondentRepository respondentRepository,
            IRespondentsValidator respondentValidator,
            ICompanySizeCache companySizeCache,
            IExperienceLevelCache experienceLevelCache,
            ICompanySizeRepository companySizeRepository,
            IExperienceLevelRepository experienceLevelRepository)
        {
            this.respondentsReader = respondentsReader;
            this.respondentRepository = respondentRepository;
            this.respondentValidator = respondentValidator;
            this.companySizeCache = companySizeCache;
            this.experienceLevelCache = experienceLevelCache;
            this.companySizeRepository = companySizeRepository;
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
            IQueryable<RespondentInfo> respInfo = this.respondentRepository.GetFiltered(this.CreateRespondentsQuery(filter));

            if (!string.IsNullOrEmpty(filter.CompanySize))
            {
                respInfo = from res in respInfo
                            join cmp in this.companySizeRepository.GetAll()
                            on res.CompanySize equals cmp.Size
                            where cmp.Class == filter.CompanySize
                           select res;
            }

            if (!string.IsNullOrEmpty(filter.ExperienceLevel))
            {
                respInfo = from res in respInfo
                    join exp in this.experienceLevelRepository.GetAll()
                        on res.ExperienceLevel equals exp.YearsProgram
                    where exp.Level == filter.ExperienceLevel
                    select res;
            }

            IEnumerable<Respondent> respondents = 
                respInfo
                .Select(respondent => new Respondent
                {
                    Id = respondent.Id,
                    Country = respondent.Country,
                    DeveloperType = respondent.DeveloperType,
                    Gender = respondent.Gender,
                    Professional = respondent.Professional,
                    CompanySize = respondent.CompanySize,
                    Language = respondent.Language,
                    VersionControl = respondent.VersionControl,
                    WorkStart = respondent.WorkStart,
                    ExperienceLevel = respondent.ExperienceLevel,
                    CareerSatisfaction = respondent.CareerSatisfaction,
                    JobSatisfaction = respondent.JobSatisfaction
                });


            respondents = respondents.ToList();

            foreach (Respondent respondent in respondents)
            {
                respondent.CompanySize = this.companySizeCache.GetCompanyClass(respondent.CompanySize);
                respondent.ExperienceLevel = this.experienceLevelCache.GetExperienceLevel(respondent.ExperienceLevel);
            }

            return respondents;
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

        /*private Respondent MapRespondent(RespondentInfo respondent)
        {
            Respondent newRespondent = new Respondent
            {
                Id = respondent.Id,
                Country = respondent.Country,
                DeveloperType = respondent.DeveloperType,
                Gender = respondent.Gender,
                Professional = respondent.Professional,
                CompanySize = this.companySizeCache.GetCompanyClass(respondent.CompanySize),
                Language = respondent.Language,
                VersionControl = respondent.VersionControl,
                WorkStart = respondent.WorkStart,
                ExperienceLevel = this.experienceLevelCache.GetExperienceLevel(respondent.ExperienceLevel),
                CareerSatisfaction = respondent.CareerSatisfaction,
                JobSatisfaction = respondent.JobSatisfaction
             };

            return newRespondent;
        }*/
    }
}