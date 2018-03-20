using System.Collections.Generic;
using System.Linq;

using StackOverflowSurvey.Domain.Entities;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Extensibility;

namespace StackOverflowSurvey.Service
{
    internal class CompanySizeCache : ICompanySizeCache
    {
        private static List<CompanySize> companySizesCache = new List<CompanySize>();
        private readonly ICompanySizeRepository companySizeRepository;
        private bool isInitialized = false;

        public CompanySizeCache(ICompanySizeRepository companySizeRepository)
        {
            this.companySizeRepository = companySizeRepository;
        }

        public string GetCompanyClass(string size)
        {
            EnsureCompanySizesLoaded();
            return companySizesCache.FirstOrDefault(companySize => companySize.Size == size)?.Class;
        }

        private void EnsureCompanySizesLoaded()
        {
            if (!isInitialized)
            {
                companySizesCache.AddRange(companySizeRepository.GetAll());
                isInitialized = true;
            }
        }
    }
}