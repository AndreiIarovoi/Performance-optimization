using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Service
{
    using Ninject.Modules;
    using SurveyImport;

    public class SurveyServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRespondentsReader>().To<RespondentsReader>();
            Bind<IRespondentsService>().To<RespondentsService>();
            Bind<IRespondentsValidator>().To<RespondentsValidator>();
            Bind<ICompanySizeCache>().To<CompanySizeCache>();
            Bind<IExperienceLevelCache>().To<ExperienceLevelCache>();
        }
    }
}