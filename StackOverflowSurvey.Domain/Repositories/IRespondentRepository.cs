using System.Collections.Generic;

using StackOverflowSurvey.Domain.Dto;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public interface IRespondentRepository
    {
        IEnumerable<Respondent> GetAll();

        IEnumerable<Respondent> GetFiltered(RespondentsQuery query);

        void AddRange(IEnumerable<Respondent> respondents);
    }
}