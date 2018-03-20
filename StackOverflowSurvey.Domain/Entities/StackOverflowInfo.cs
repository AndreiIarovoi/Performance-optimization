namespace StackOverflowSurvey.Domain.Entities
{
    public class StackOverflowInfo : IEntity
    {
        public int Id { get; set; }
        public string StackOverflowDescribes { get; set; }
        public string StackOverflowSatisfaction { get; set; }
        public string StackOverflowDevices { get; set; }
        public string StackOverflowFoundAnswer { get; set; }
        public string StackOverflowCopiedCode { get; set; }
        public string StackOverflowJobListing { get; set; }
        public string StackOverflowCompanyPage { get; set; }
        public string StackOverflowJobSearch { get; set; }
        public string StackOverflowNewQuestion { get; set; }
        public string StackOverflowAnswer { get; set; }
        public string StackOverflowMetaChat { get; set; }
        public string StackOverflowAdsRelevant { get; set; }
        public string StackOverflowAdsDistracting { get; set; }
        public string StackOverflowModeration { get; set; }
        public string StackOverflowCommunity { get; set; }
        public string StackOverflowHelpful { get; set; }
        public string StackOverflowBetter { get; set; }
        public string StackOverflowWhatDo { get; set; }
        public string StackOverflowMakeMoney { get; set; }
    }
}