namespace StackOverflowSurvey.Domain.Entities
{
    public class HaveWorkedAndWant : IEntity
    {
        public int Id { get; set; }
        public string HaveWorkedLanguage { get; set; }
        public string WantWorkLanguage { get; set; }
        public string HaveWorkedFramework { get; set; }
        public string WantWorkFramework { get; set; }
        public string HaveWorkedDatabase { get; set; }
        public string WantWorkDatabase { get; set; }
        public string HaveWorkedPlatform { get; set; }
        public string WantWorkPlatform { get; set; }
    }
}