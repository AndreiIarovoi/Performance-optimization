using System.Collections.Generic;
using System.Data.Entity;

using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Repository(SurveyContext context)
        {
            Context = context;
        }

        protected IDbSet<TEntity> Entities { get; set; }

        protected SurveyContext Context { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }
    }
}