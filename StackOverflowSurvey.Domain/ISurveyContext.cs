using System.Data.Entity;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain
{
    public interface ISurveyContext
    {
        IDbSet<Assess> Assesses { get; set; }
        IDbSet<Education> Education { get; set; }
        IDbSet<Employment> Employment { get; set; }
        IDbSet<Equipment> Equipment { get; set; }
        IDbSet<ExCoder> ExCoder { get; set; }
        IDbSet<HaveWorkedAndWant> HaveWorkedAndWant { get; set; }
        IDbSet<ImportantHiring> ImportantHiring { get; set; }
        IDbSet<Influence> Influence { get; set; }
        IDbSet<JobInfo> JobInfo { get; set; }
        IDbSet<RespondentDetails> RespondentDetails { get; set; }
        IDbSet<Respondent> Respondents { get; set; }
        IDbSet<StackOverflowInfo> StackOverflowInfo { get; set; }
        IDbSet<TechnicalDetails> TechnicalDetails { get; set; }
        IDbSet<Country> Countries { get; set; }
        IDbSet<CompanySize> CompanySizes { get; set; }
        IDbSet<ExperienceLevel> ExperienceLevels { get; set; }
    }
}