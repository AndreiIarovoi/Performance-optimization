using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public class CompanySizeRepository : Repository<CompanySize>, ICompanySizeRepository
    {
        public CompanySizeRepository(SurveyContext context) : base(context)
        {
            Entities = context.CompanySizes;
        }
    }
}