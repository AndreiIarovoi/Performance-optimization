namespace StackOverflowSurvey.Domain.Entities
{
    public class Education : IEntity
    {
        public int Id { get; set; }
        public string University { get; set; }
        public string FormalEducation { get; set; }
        public string MajorUndergrad { get; set; }
        public string EducationImportant { get; set; }
        public string EducationTypes { get; set; }
        public string SelfTaughtTypes { get; set; }
        public string TimeAfterBootcamp { get; set; }
        public string CousinEducation { get; set; }
        public string HighestEducationParents { get; set; }
    }
}