using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using StackOverflowSurvey.Domain.Dto;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public class RespondentRepository : IRespondentRepository
    {
        private readonly SurveyContext context;

        public RespondentRepository(SurveyContext context)
        {
            this.context = context;
            this.context.Database.CommandTimeout = 600;
        }

        public IEnumerable<Respondent> GetAll()
        {
            return context.Respondents.Include(r => r.HaveWorkedAndWantInfo).Include(r => r.EducationInfo)
                .Include(r => r.Job).Include(r => r.EducationInfo).Include(r => r.TechnicalDetailsInfo).Include(r => r.EmploymentInfo).AsEnumerable();
        }

        public IEnumerable<Respondent> GetFiltered(RespondentsQuery query)
        {
            return GetAll().Where(
                r => (string.IsNullOrEmpty(query.Professional) || r.Professional.Contains(query.Professional)) 
                     && (string.IsNullOrEmpty(query.Country) || r.Country.Contains(query.Country))
                     && (string.IsNullOrEmpty(query.DeveloperType) || r.EmploymentInfo.DeveloperType.Contains(query.DeveloperType))
                     && (string.IsNullOrEmpty(query.Language) || r.HaveWorkedAndWantInfo.HaveWorkedLanguage.Contains(query.Language))
                     && (string.IsNullOrEmpty(query.VersionControl) || r.TechnicalDetailsInfo.VersionControl.Contains(query.VersionControl))
                     && (string.IsNullOrEmpty(query.Gender) || r.Gender.Contains(query.Gender)));
        }

        public void AddRange(IEnumerable<Respondent> respondents)
        {
            foreach (Respondent respondent in respondents)
            {
                context.Respondents.Add(respondent);
            }
            context.SaveChanges();
        }
    }
}