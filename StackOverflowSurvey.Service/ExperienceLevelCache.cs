using System.Collections.Generic;
using System.Linq;
using StackOverflowSurvey.Domain.Entities;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Service
{
    class ExperienceLevelCache : IExperienceLevelCache
    {
        private static IList<ExperienceLevel> experienceLevelCache;
        private readonly IExperienceLevelRepository experienceLevelRepository;

        public ExperienceLevelCache(IExperienceLevelRepository experienceLevelRepository)
        {
            this.experienceLevelRepository = experienceLevelRepository;
            this.SetExperienceLevelCache();
        }

        public string GetExperienceLevelCache(string level)
        {
            return experienceLevelCache.FirstOrDefault(experienceLevel => experienceLevel.YearsProgram == level)?.Level;
        }

        private void SetExperienceLevelCache()
        {
            if (experienceLevelCache == null || !experienceLevelCache.Any())
            {
                experienceLevelCache = this.experienceLevelRepository.GetAll().ToList();
            }
        }
    }
}
