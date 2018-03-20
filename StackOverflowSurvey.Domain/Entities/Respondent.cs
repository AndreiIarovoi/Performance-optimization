namespace StackOverflowSurvey.Domain.Entities
{
    public class Respondent : IEntity
    {
        public int Id { get; set; }
        public string RespondentName { get; set; }
        public string Professional { get; set; }
        public string ProgramHobby { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Salary { get; set; }
        public string ExpectedSalary { get; set; }
        public string SurveyLong { get; set; }
        public string QuestionsInteresting { get; set; }
        public string QuestionsConfusing { get; set; }
        public string InterestedAnswers { get; set; }

        public Assess Assesses { get; set; }
        public Education EducationInfo { get; set; }
        public Employment EmploymentInfo { get; set; }
        public Equipment EquipmentInfo { get; set; }
        public ExCoder ExCoderInfo { get; set; }
        public HaveWorkedAndWant HaveWorkedAndWantInfo { get; set; }
        public ImportantHiring ImportantHiringInfo { get; set; }
        public Influence InfluenceInfo { get; set; }
        public JobInfo Job { get; set; }
        public RespondentDetails RespondentDetailsInfo { get; set; }
        public StackOverflowInfo StackOverflow { get; set; }
        public TechnicalDetails TechnicalDetailsInfo { get; set; }
    }
}
