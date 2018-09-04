using System.Collections.Generic;
using System.Linq;

using StackOverflowSurvey.Domain.Entities;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Service
{
    internal class CompanySizeCache : ICompanySizeCache
    {
        private static IDictionary<string, string> companySizesCache;

        private readonly ICompanySizeRepository companySizeRepository;

        public CompanySizeCache(ICompanySizeRepository companySizeRepository)
        {
            this.companySizeRepository = companySizeRepository;
            SetCompanySizeCache();
        }

        public string GetCompanyClass(string size)
        {
            return companySizesCache[size];
        }

        private void SetCompanySizeCache()
        {
            if (companySizesCache == null || !companySizesCache.Any())
            {
                companySizesCache = this.companySizeRepository.GetAll().ToDictionary(cmp => cmp.Size, cmp => cmp.Class);
            }
        }
    }
}