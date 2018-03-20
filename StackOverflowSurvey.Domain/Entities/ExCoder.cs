namespace StackOverflowSurvey.Domain.Entities
{
    public class ExCoder : IEntity
    {
        public int Id { get; set; }
        public string ExCoderReturn { get; set; }
        public string ExCoderNotForMe { get; set; }
        public string ExCoderBalance { get; set; }
        public string ExCoder10Years { get; set; }
        public string ExCoderBelonged { get; set; }
        public string ExCoderSkills { get; set; }
        public string ExCoderWillNotCode { get; set; }
        public string ExCoderActive { get; set; }
    }
}