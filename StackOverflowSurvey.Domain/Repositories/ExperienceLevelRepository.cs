using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public class ExperienceLevelRepository: Repository<ExperienceLevel>, IExperienceLevelRepository
    {
        public ExperienceLevelRepository(SurveyContext context)
            : base(context)
        {
            Entities = context.ExperienceLevels;
        }
    }
}