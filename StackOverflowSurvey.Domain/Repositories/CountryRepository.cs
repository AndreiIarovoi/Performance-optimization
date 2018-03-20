using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(SurveyContext context) : base(context)
        {
            Entities = context.Countries;
        }
    }
}