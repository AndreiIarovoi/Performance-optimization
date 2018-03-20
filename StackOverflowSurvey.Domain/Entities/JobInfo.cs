namespace StackOverflowSurvey.Domain.Entities
{
    public class JobInfo : IEntity
    {
        public int Id { get; set; }
        public string JobSeekingStatus { get; set; }
        public string HoursPerWeek { get; set; }
        public string WorkStart { get; set; }
        public string LastNewJob { get; set; }
        public string ImportantBenefits { get; set; }
        public string ClickyKeys { get; set; }
        public string JobProfile { get; set; }
        public string ResumePrompted { get; set; }
        public string Currency { get; set; }
        public string Overpaid { get; set; }
    }
}