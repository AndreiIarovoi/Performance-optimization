namespace StackOverflowSurvey.Domain.Entities
{
    public class Influence : IEntity
    {
        public int Id { get; set; }
        public string InfluenceInternet { get; set; }
        public string InfluenceWorkstation { get; set; }
        public string InfluenceHardware { get; set; }
        public string InfluenceServers { get; set; }
        public string InfluenceTechStack { get; set; }
        public string InfluenceDeptTech { get; set; }
        public string InfluenceVizTools { get; set; }
        public string InfluenceDatabase { get; set; }
        public string InfluenceCloud { get; set; }
        public string InfluenceConsultants { get; set; }
        public string InfluenceRecruitment { get; set; }
        public string InfluenceCommunication { get; set; }
    }
}