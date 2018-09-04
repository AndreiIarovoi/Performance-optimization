using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflowSurvey.Domain.Entities;
using StackOverflowSurvey.Domain.Repositories;
using StackOverflowSurvey.Service.Extensibility;
using Respondent = StackOverflowSurvey.Domain.Entities.Respondent;

namespace StackOverflowSurvey.Service
{
    public class RespondentsValidator : IRespondentsValidator
    {
        private readonly ICountryRepository countryRepository;
        private IList<Country> countries;

        public RespondentsValidator(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
            this.countries = this.GetCountries();
        }

        public IEnumerable<string> Validate(IEnumerable<Respondent> respondents)
        {
            foreach (Respondent respondent in respondents)
            {
                yield return ValidateRespondent(respondent);
            }
        }

        private string ValidateRespondent(Respondent respondent)
        {
            string errors = String.Empty;

            if (String.IsNullOrEmpty(respondent.RespondentName))
            {
                errors += "Respondent must have RespondentName;";
            }

            if (this.countries.All(c => c.Name != respondent.Country))
            {
                errors += $"Unknown Country for respondent: {respondent.RespondentName}";
            }

            return errors;
        }

        private IList<Country> GetCountries()
        {
            if (this.countries == null || !this.countries.Any())
            {
                return this.countryRepository.GetAll().ToList();
            }

            return this.countries;
        }
    }
}