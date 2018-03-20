namespace StackOverflowSurvey.Service.SurveyImport
{
    using CsvHelper.Configuration;

    using Domain.Entities;

    public class RespondentCsvClassMap : CsvClassMap<Respondent>
    {
        public RespondentCsvClassMap()
        {
            Map(r => r.Id).Ignore();
            Map(r => r.Country);
            Map(r => r.ExpectedSalary);
            Map(r => r.Gender);
            Map(r => r.InterestedAnswers);
            Map(r => r.Professional);
            Map(r => r.ProgramHobby);
            Map(r => r.QuestionsConfusing);
            Map(r => r.QuestionsInteresting);
            Map(r => r.Race);
            Map(r => r.Salary);
            Map(r => r.SurveyLong);
            Map(r => r.RespondentName).Name("Respondent");
            References<EntityCsvClassMap<Assess>>(r => r.Assesses);
            References<EntityCsvClassMap<Education>>(r => r.EducationInfo);
            References<EntityCsvClassMap<Employment>>(r => r.EmploymentInfo);
            References<EntityCsvClassMap<Equipment>>(r => r.EquipmentInfo);
            References<EntityCsvClassMap<ExCoder>>(r => r.ExCoderInfo);
            References<EntityCsvClassMap<HaveWorkedAndWant>>(r => r.HaveWorkedAndWantInfo);
            References<EntityCsvClassMap<ImportantHiring>>(r => r.ImportantHiringInfo);
            References<EntityCsvClassMap<Influence>>(r => r.InfluenceInfo);
            References<EntityCsvClassMap<JobInfo>>(r => r.Job);
            References<EntityCsvClassMap<RespondentDetails>>(r => r.RespondentDetailsInfo);
            References<EntityCsvClassMap<StackOverflowInfo>>(r => r.StackOverflow);
            References<EntityCsvClassMap<TechnicalDetails>>(r => r.TechnicalDetailsInfo);
        }
    }
}