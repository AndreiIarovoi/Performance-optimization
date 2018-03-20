using System.Collections.Generic;
using System.Linq;
using StackOverflowSurvey.Domain.Entities;
namespace StackOverflowSurvey.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SurveyContext context)
        {
        }
    }
}