using System.Collections.Generic;
using System.Linq;
using StackOverflowSurvey.Domain.Entities;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Service
{
    class ExperienceLevelCache : IExperienceLevelCache
    {
        private IList<ExperienceLevel> experienceLevelCache;
        private readonly IExperienceLevelRepository experienceLevelRepository;

        public ExperienceLevelCache(IExperienceLevelRepository experienceLevelRepository)
        {
            this.experienceLevelRepository = experienceLevelRepository;
            experienceLevelCache = this.experienceLevelRepository.GetAll().ToList();
        }

        public string GetExperienceLevelCache(string level)
        {
            return experienceLevelCache.FirstOrDefault(experienceLevel => experienceLevel.YearsProgram == level)?.Level;
        }
    }
}
