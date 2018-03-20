namespace StackOverflowSurvey.Domain.Entities
{
    public class Assess: IEntity
    {
        public int Id { get; set; }
        public string AssessJobIndustry { get; set; }
        public string AssessJobRole { get; set; }
        public string AssessJobExp { get; set; }
        public string AssessJobDept { get; set; }
        public string AssessJobTech { get; set; }
        public string AssessJobProjects { get; set; }
        public string AssessJobCompensation { get; set; }
        public string AssessJobOffice { get; set; }
        public string AssessJobCommute { get; set; }
        public string AssessJobRemote { get; set; }
        public string AssessJobLeaders { get; set; }
        public string AssessJobProfDevel { get; set; }
        public string AssessJobDiversity { get; set; }
        public string AssessJobProduct { get; set; }
        public string AssessJobFinances { get; set; }
    }
}