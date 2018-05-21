using System.Linq;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public interface IRepository<out TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();
    }
}