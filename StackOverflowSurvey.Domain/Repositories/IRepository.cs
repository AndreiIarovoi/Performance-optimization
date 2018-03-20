using System.Collections.Generic;

using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public interface IRepository<out TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
    }
}