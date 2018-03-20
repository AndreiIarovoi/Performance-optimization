namespace StackOverflowSurvey.Domain.Entities
{
    public class ExperienceLevel : IEntity
    {
        public int Id { get; set; }

        public string YearsProgram { get; set; }

        public string Level { get; set; }
    }
}