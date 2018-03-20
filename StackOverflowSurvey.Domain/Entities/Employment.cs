namespace StackOverflowSurvey.Domain.Entities
{
    public class Employment : IEntity
    {
        public int Id { get; set; }
        public string EmploymentStatus { get; set; }
        public string HomeRemote { get; set; }
        public string CompanySize { get; set; }
        public string CompanyType { get; set; }
        public string YearsProgram { get; set; }
        public string YearsCodedJob { get; set; }
        public string YearsCodedJobPast { get; set; }
        public string DeveloperType { get; set; }
        public string WebDeveloperType { get; set; }
        public string MobileDeveloperType { get; set; }
        public string NonDeveloperType { get; set; }
        public string CareerSatisfaction { get; set; }
        public string JobSatisfaction { get; set; }
    }
}