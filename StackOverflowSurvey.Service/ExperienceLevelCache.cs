using System.Collections.Generic;
using System.Linq;
using StackOverflowSurvey.Domain.Entities;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Service
{
    class ExperienceLevelCache : IExperienceLevelCache
    {
        private static IDictionary<string, string> experienceLevelCache;

        private readonly IExperienceLevelRepository experienceLevelRepository;

        public ExperienceLevelCache(IExperienceLevelRepository experienceLevelRepository)
        {
            this.experienceLevelRepository = experienceLevelRepository;
            this.SetExperienceLevelCache();
        }

        public string GetExperienceLevel(string yearsProgram)
        {
            return experienceLevelCache[yearsProgram];
        }

        private void SetExperienceLevelCache()
        {
            if (experienceLevelCache == null || !experienceLevelCache.Any())
            {
                experienceLevelCache = this.experienceLevelRepository.GetAll().ToDictionary(cmp => cmp.YearsProgram, cmp => cmp.Level);
            }
        }
    }
}
