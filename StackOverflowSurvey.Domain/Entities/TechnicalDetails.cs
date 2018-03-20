namespace StackOverflowSurvey.Domain.Entities
{
    public class TechnicalDetails : IEntity
    {
        public int Id { get; set; }
        public string IDE { get; set; }
        public string AuditoryEnvironment { get; set; }
        public string Methodology { get; set; }
        public string VersionControl { get; set; }
        public string CheckInCode { get; set; }
        public string ShipIt { get; set; }
        public string OtherPeoplesCode { get; set; }
        public string ProjectManagement { get; set; }
        public string EnjoyDebugging { get; set; }
        public string InTheZone { get; set; }
        public string DifficultCommunication { get; set; }
        public string CollaborateRemote { get; set; }
        public string MetricAssess { get; set; }
        public string TabsSpaces { get; set; }
    }
}