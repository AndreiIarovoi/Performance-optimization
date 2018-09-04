using System.Collections.Generic;
using System.Linq;

using StackOverflowSurvey.Domain.Entities;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Service
{
    internal class CompanySizeCache : ICompanySizeCache
    {
        private static IList<CompanySize> companySizesCache;
        private readonly ICompanySizeRepository companySizeRepository;

        public CompanySizeCache(ICompanySizeRepository companySizeRepository)
        {
            this.companySizeRepository = companySizeRepository;
            SetCompanySizeCache();
        }

        public string GetCompanySizesCache(string size)
        {
            return companySizesCache.FirstOrDefault(companySize => companySize.Size == size)?.Class;
        }

        private void SetCompanySizeCache()
        {
            if (companySizesCache == null || !companySizesCache.Any())
            {
                companySizesCache = this.companySizeRepository.GetAll().ToList();
            }
        }
    }
}