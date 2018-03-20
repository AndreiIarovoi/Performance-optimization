using System.Data.Entity;
using System.Linq;

using StackOverflowSurvey.Domain.Seed;

namespace StackOverflowSurvey.Domain
{
    public class SurveyDatabaseInitializer : CreateDatabaseIfNotExists<SurveyContext>
    {
        protected override void Seed(SurveyContext context)
        {
            SurveySeeder.ReadCountries().ToList().ForEach(c => context.Countries.Add(c));
            SurveySeeder.ReadCompanySizes().ToList().ForEach(c => context.CompanySizes.Add(c));
            SurveySeeder.ReadExperienceLevels().ToList().ForEach(e => context.ExperienceLevels.Add(e));
            context.SaveChanges();
        }
    }
}