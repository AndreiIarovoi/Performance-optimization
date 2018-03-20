using System.Collections.Generic;

using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Service.Extensibility
{
    public interface IRespondentsValidator
    {
        IEnumerable<string> Validate(IEnumerable<Respondent> respondents);
    }
}