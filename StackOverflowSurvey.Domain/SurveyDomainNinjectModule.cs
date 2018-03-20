using Ninject.Modules;
using StackOverflowSurvey.Domain.Repositories;

namespace StackOverflowSurvey.Domain
{
    public class SurveyDomainNinjectModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ISurveyContext>().To<SurveyContext>();
            Bind<IRespondentRepository>().To<RespondentRepository>();
            Bind<ICountryRepository>().To<CountryRepository>();
            Bind<IExperienceLevelRepository>().To<ExperienceLevelRepository>();
            Bind<ICompanySizeRepository>().To<CompanySizeRepository>();
        }
    }
}