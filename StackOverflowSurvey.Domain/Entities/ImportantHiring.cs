namespace StackOverflowSurvey.Domain.Entities
{
    public class ImportantHiring : IEntity
    {
        public int Id { get; set; }
        public string LearnedHiring { get; set; }
        public string ImportantHiringAlgorithms { get; set; }
        public string ImportantHiringTechExp { get; set; }
        public string ImportantHiringCommunication { get; set; }
        public string ImportantHiringOpenSource { get; set; }
        public string ImportantHiringPMExp { get; set; }
        public string ImportantHiringCompanies { get; set; }
        public string ImportantHiringTitles { get; set; }
        public string ImportantHiringEducation { get; set; }
        public string ImportantHiringRep { get; set; }
        public string ImportantHiringGettingThingsDone { get; set; }
    }
}