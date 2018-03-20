using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Seed
{
    public class SurveySeeder
    {
        private const string CountriesData = "\\SeedData\\Countries.csv";
        private const string CompanySizeData = "\\SeedData\\CompanySize.csv";
        private const string ExperienceLevelData = "\\SeedData\\ExperienceLevel.csv";

        public static IEnumerable<Country> ReadCountries()
        {
            return ReadData<Country>(CountriesData);
        }

        public static IEnumerable<CompanySize> ReadCompanySizes()
        {
            return ReadData<CompanySize>(CompanySizeData);
        }

        public static IEnumerable<ExperienceLevel> ReadExperienceLevels()
        {
            return ReadData<ExperienceLevel>(ExperienceLevelData);
        }

        private static IEnumerable<TData> ReadData<TData>(string filePath)
            where TData : IEntity
        {
            string path = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath) + filePath;

            if (File.Exists(path))
            {
                using (var streamReader = new StreamReader(File.OpenRead(path)))
                {
                    using (var csvReader = new CsvReader(streamReader))
                    {
                        csvReader.Configuration.RegisterClassMap<EntityCsvClassMap<TData>>();
                        var items = new List<TData>();

                        while (csvReader.Read())
                        {
                            var record = csvReader.GetRecord<TData>();
                            items.Add(record);
                        }

                        return items;
                    }
                }
            }

            return Enumerable.Empty<TData>();
        }
    }
}