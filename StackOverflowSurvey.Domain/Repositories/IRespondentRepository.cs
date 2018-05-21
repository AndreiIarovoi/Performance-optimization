using System.Collections.Generic;
using System.Linq;
using StackOverflowSurvey.Domain.Dto;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public interface IRespondentRepository
    {
        IQueryable<Respondent> GetAll();

        IQueryable<RespondentInfo> GetAllRespondentInfo();

        IQueryable<RespondentInfo> GetFiltered(RespondentsQuery query);

        void AddRange(IEnumerable<Respondent> respondents);
    }
}