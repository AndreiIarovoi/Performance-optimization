using System.Collections.Generic;
using System.Web;
using System.Web.Http;

using StackOverflowSurvey.Service;
using StackOverflowSurvey.Service.Dto;
using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Web.Controllers
{
    public class RespondentsController : ApiController
    {
        private readonly IRespondentsService respondentsService;

        public RespondentsController(IRespondentsService respondentsService)
        {
            this.respondentsService = respondentsService;
        }

        [HttpGet]
        public IEnumerable<Respondent> GetAll([FromUri]RespondentsFilter filter)
        {
            return respondentsService.GetRespondents(filter);
        }

        [HttpPost]
        public IEnumerable<RespondentsCreationResult> Upload()
        {
            IEnumerable<PostedFile> files = RespondentsLoader.LoadRespondentFiles(HttpContext.Current.Request.Files);
            return respondentsService.CreateRespondents(files);
        }
    }
}