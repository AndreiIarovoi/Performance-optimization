using System.Collections.Generic;
using System.IO;

using CsvHelper;

using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Service.SurveyImport
{
    public interface IRespondentsReader
    {
        IEnumerable<Respondent> ReadRespondents(PostedFile file);
    }

    public class RespondentsReader : IRespondentsReader
    {
        public IEnumerable<Respondent> ReadRespondents(PostedFile file)
        {
            using (var streamReader = new StreamReader(file.InputStream))
            {
                using (var csvReader = new CsvReader(streamReader))
                {
                    csvReader.Configuration.RegisterClassMap<RespondentCsvClassMap>();

                    while (csvReader.Read())
                    {
                        yield return csvReader.GetRecord<Respondent>();
                    }
                }
            }
        }
    }
}