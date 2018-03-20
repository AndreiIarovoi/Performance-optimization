using CsvHelper.Configuration;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Service.SurveyImport
{
    public class EntityCsvClassMap<TEntity> : CsvClassMap<TEntity> where TEntity : IEntity
    {
        public EntityCsvClassMap()
        {
            AutoMap();
            Map(e => e.Id).Ignore();
        }
    }
}