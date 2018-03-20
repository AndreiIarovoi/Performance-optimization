namespace StackOverflowSurvey.Domain.Entities
{
    public class CompanySize : IEntity
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public string Class { get; set; }
    }
}