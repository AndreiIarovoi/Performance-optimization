using System.Data.Entity;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain
{
    public class SurveyContext : DbContext, ISurveyContext
    {
        public SurveyContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new SurveyDatabaseInitializer());
        }

        public IDbSet<Respondent> Respondents { get; set; }
        public IDbSet<Assess> Assesses { get; set; }
        public IDbSet<Education> Education { get; set; }
        public IDbSet<Employment> Employment { get; set; }
        public IDbSet<Equipment> Equipment { get; set; }
        public IDbSet<ExCoder> ExCoder { get; set; }
        public IDbSet<HaveWorkedAndWant> HaveWorkedAndWant { get; set; }
        public IDbSet<ImportantHiring> ImportantHiring { get; set; }
        public IDbSet<Influence> Influence { get; set; }
        public IDbSet<JobInfo> JobInfo { get; set; }
        public IDbSet<RespondentDetails> RespondentDetails { get; set; }
        public IDbSet<StackOverflowInfo> StackOverflowInfo { get; set; }
        public IDbSet<TechnicalDetails> TechnicalDetails { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<CompanySize> CompanySizes { get; set; }
        public IDbSet<ExperienceLevel> ExperienceLevels { get; set; }
    }
}
