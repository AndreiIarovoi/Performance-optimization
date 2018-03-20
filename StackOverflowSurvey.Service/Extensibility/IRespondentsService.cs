using System.Collections.Generic;

using StackOverflowSurvey.Service.Dto;

namespace StackOverflowSurvey.Service.Extensibility
{
    public interface IRespondentsService
    {
        IEnumerable<RespondentsCreationResult> CreateRespondents(IEnumerable<PostedFile> postedFiles);

        IEnumerable<Respondent> GetRespondents(RespondentsFilter filter);
    }
}