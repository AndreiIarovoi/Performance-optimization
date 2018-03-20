namespace StackOverflowSurvey.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssessJobIndustry = c.String(),
                        AssessJobRole = c.String(),
                        AssessJobExp = c.String(),
                        AssessJobDept = c.String(),
                        AssessJobTech = c.String(),
                        AssessJobProjects = c.String(),
                        AssessJobCompensation = c.String(),
                        AssessJobOffice = c.String(),
                        AssessJobCommute = c.String(),
                        AssessJobRemote = c.String(),
                        AssessJobLeaders = c.String(),
                        AssessJobProfDevel = c.String(),
                        AssessJobDiversity = c.String(),
                        AssessJobProduct = c.String(),
                        AssessJobFinances = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanySizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                        Class = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        University = c.String(),
                        FormalEducation = c.String(),
                        MajorUndergrad = c.String(),
                        EducationImportant = c.String(),
                        EducationTypes = c.String(),
                        SelfTaughtTypes = c.String(),
                        TimeAfterBootcamp = c.String(),
                        CousinEducation = c.String(),
                        HighestEducationParents = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentStatus = c.String(),
                        HomeRemote = c.String(),
                        CompanySize = c.String(),
                        CompanyType = c.String(),
                        YearsProgram = c.String(),
                        YearsCodedJob = c.String(),
                        YearsCodedJobPast = c.String(),
                        DeveloperType = c.String(),
                        WebDeveloperType = c.String(),
                        MobileDeveloperType = c.String(),
                        NonDeveloperType = c.String(),
                        CareerSatisfaction = c.String(),
                        JobSatisfaction = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentSatisfiedMonitors = c.String(),
                        EquipmentSatisfiedCPU = c.String(),
                        EquipmentSatisfiedRAM = c.String(),
                        EquipmentSatisfiedStorage = c.String(),
                        EquipmentSatisfiedRW = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExCoders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExCoderReturn = c.String(),
                        ExCoderNotForMe = c.String(),
                        ExCoderBalance = c.String(),
                        ExCoder10Years = c.String(),
                        ExCoderBelonged = c.String(),
                        ExCoderSkills = c.String(),
                        ExCoderWillNotCode = c.String(),
                        ExCoderActive = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperienceLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearsProgram = c.String(),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HaveWorkedAndWants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HaveWorkedLanguage = c.String(),
                        WantWorkLanguage = c.String(),
                        HaveWorkedFramework = c.String(),
                        WantWorkFramework = c.String(),
                        HaveWorkedDatabase = c.String(),
                        WantWorkDatabase = c.String(),
                        HaveWorkedPlatform = c.String(),
                        WantWorkPlatform = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImportantHirings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LearnedHiring = c.String(),
                        ImportantHiringAlgorithms = c.String(),
                        ImportantHiringTechExp = c.String(),
                        ImportantHiringCommunication = c.String(),
                        ImportantHiringOpenSource = c.String(),
                        ImportantHiringPMExp = c.String(),
                        ImportantHiringCompanies = c.String(),
                        ImportantHiringTitles = c.String(),
                        ImportantHiringEducation = c.String(),
                        ImportantHiringRep = c.String(),
                        ImportantHiringGettingThingsDone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Influences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InfluenceInternet = c.String(),
                        InfluenceWorkstation = c.String(),
                        InfluenceHardware = c.String(),
                        InfluenceServers = c.String(),
                        InfluenceTechStack = c.String(),
                        InfluenceDeptTech = c.String(),
                        InfluenceVizTools = c.String(),
                        InfluenceDatabase = c.String(),
                        InfluenceCloud = c.String(),
                        InfluenceConsultants = c.String(),
                        InfluenceRecruitment = c.String(),
                        InfluenceCommunication = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobSeekingStatus = c.String(),
                        HoursPerWeek = c.String(),
                        WorkStart = c.String(),
                        LastNewJob = c.String(),
                        ImportantBenefits = c.String(),
                        ClickyKeys = c.String(),
                        JobProfile = c.String(),
                        ResumePrompted = c.String(),
                        Currency = c.String(),
                        Overpaid = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RespondentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PronounceGIF = c.String(),
                        ProblemSolving = c.String(),
                        BuildingThings = c.String(),
                        LearningNewTech = c.String(),
                        BoringDetails = c.String(),
                        JobSecurity = c.String(),
                        DiversityImportant = c.String(),
                        AnnoyingUI = c.String(),
                        FriendsDevelopers = c.String(),
                        RightWrongWay = c.String(),
                        UnderstandComputers = c.String(),
                        SeriousWork = c.String(),
                        InvestTimeTools = c.String(),
                        WorkPayCare = c.String(),
                        KinshipDevelopers = c.String(),
                        ChallengeMyself = c.String(),
                        CompetePeers = c.String(),
                        ChangeWorld = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Respondents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RespondentName = c.String(),
                        Professional = c.String(),
                        ProgramHobby = c.String(),
                        Country = c.String(),
                        Gender = c.String(),
                        Race = c.String(),
                        Salary = c.String(),
                        ExpectedSalary = c.String(),
                        SurveyLong = c.String(),
                        QuestionsInteresting = c.String(),
                        QuestionsConfusing = c.String(),
                        InterestedAnswers = c.String(),
                        Assesses_Id = c.Int(),
                        EducationInfo_Id = c.Int(),
                        EmploymentInfo_Id = c.Int(),
                        EquipmentInfo_Id = c.Int(),
                        ExCoderInfo_Id = c.Int(),
                        HaveWorkedAndWantInfo_Id = c.Int(),
                        ImportantHiringInfo_Id = c.Int(),
                        InfluenceInfo_Id = c.Int(),
                        Job_Id = c.Int(),
                        RespondentDetailsInfo_Id = c.Int(),
                        StackOverflow_Id = c.Int(),
                        TechnicalDetailsInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assesses", t => t.Assesses_Id)
                .ForeignKey("dbo.Educations", t => t.EducationInfo_Id)
                .ForeignKey("dbo.Employments", t => t.EmploymentInfo_Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentInfo_Id)
                .ForeignKey("dbo.ExCoders", t => t.ExCoderInfo_Id)
                .ForeignKey("dbo.HaveWorkedAndWants", t => t.HaveWorkedAndWantInfo_Id)
                .ForeignKey("dbo.ImportantHirings", t => t.ImportantHiringInfo_Id)
                .ForeignKey("dbo.Influences", t => t.InfluenceInfo_Id)
                .ForeignKey("dbo.JobInfoes", t => t.Job_Id)
                .ForeignKey("dbo.RespondentDetails", t => t.RespondentDetailsInfo_Id)
                .ForeignKey("dbo.StackOverflowInfoes", t => t.StackOverflow_Id)
                .ForeignKey("dbo.TechnicalDetails", t => t.TechnicalDetailsInfo_Id)
                .Index(t => t.Assesses_Id)
                .Index(t => t.EducationInfo_Id)
                .Index(t => t.EmploymentInfo_Id)
                .Index(t => t.EquipmentInfo_Id)
                .Index(t => t.ExCoderInfo_Id)
                .Index(t => t.HaveWorkedAndWantInfo_Id)
                .Index(t => t.ImportantHiringInfo_Id)
                .Index(t => t.InfluenceInfo_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.RespondentDetailsInfo_Id)
                .Index(t => t.StackOverflow_Id)
                .Index(t => t.TechnicalDetailsInfo_Id);
            
            CreateTable(
                "dbo.StackOverflowInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StackOverflowDescribes = c.String(),
                        StackOverflowSatisfaction = c.String(),
                        StackOverflowDevices = c.String(),
                        StackOverflowFoundAnswer = c.String(),
                        StackOverflowCopiedCode = c.String(),
                        StackOverflowJobListing = c.String(),
                        StackOverflowCompanyPage = c.String(),
                        StackOverflowJobSearch = c.String(),
                        StackOverflowNewQuestion = c.String(),
                        StackOverflowAnswer = c.String(),
                        StackOverflowMetaChat = c.String(),
                        StackOverflowAdsRelevant = c.String(),
                        StackOverflowAdsDistracting = c.String(),
                        StackOverflowModeration = c.String(),
                        StackOverflowCommunity = c.String(),
                        StackOverflowHelpful = c.String(),
                        StackOverflowBetter = c.String(),
                        StackOverflowWhatDo = c.String(),
                        StackOverflowMakeMoney = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TechnicalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDE = c.String(),
                        AuditoryEnvironment = c.String(),
                        Methodology = c.String(),
                        VersionControl = c.String(),
                        CheckInCode = c.String(),
                        ShipIt = c.String(),
                        OtherPeoplesCode = c.String(),
                        ProjectManagement = c.String(),
                        EnjoyDebugging = c.String(),
                        InTheZone = c.String(),
                        DifficultCommunication = c.String(),
                        CollaborateRemote = c.String(),
                        MetricAssess = c.String(),
                        TabsSpaces = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Respondents", "TechnicalDetailsInfo_Id", "dbo.TechnicalDetails");
            DropForeignKey("dbo.Respondents", "StackOverflow_Id", "dbo.StackOverflowInfoes");
            DropForeignKey("dbo.Respondents", "RespondentDetailsInfo_Id", "dbo.RespondentDetails");
            DropForeignKey("dbo.Respondents", "Job_Id", "dbo.JobInfoes");
            DropForeignKey("dbo.Respondents", "InfluenceInfo_Id", "dbo.Influences");
            DropForeignKey("dbo.Respondents", "ImportantHiringInfo_Id", "dbo.ImportantHirings");
            DropForeignKey("dbo.Respondents", "HaveWorkedAndWantInfo_Id", "dbo.HaveWorkedAndWants");
            DropForeignKey("dbo.Respondents", "ExCoderInfo_Id", "dbo.ExCoders");
            DropForeignKey("dbo.Respondents", "EquipmentInfo_Id", "dbo.Equipments");
            DropForeignKey("dbo.Respondents", "EmploymentInfo_Id", "dbo.Employments");
            DropForeignKey("dbo.Respondents", "EducationInfo_Id", "dbo.Educations");
            DropForeignKey("dbo.Respondents", "Assesses_Id", "dbo.Assesses");
            DropIndex("dbo.Respondents", new[] { "TechnicalDetailsInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "StackOverflow_Id" });
            DropIndex("dbo.Respondents", new[] { "RespondentDetailsInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "Job_Id" });
            DropIndex("dbo.Respondents", new[] { "InfluenceInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "ImportantHiringInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "HaveWorkedAndWantInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "ExCoderInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "EquipmentInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "EmploymentInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "EducationInfo_Id" });
            DropIndex("dbo.Respondents", new[] { "Assesses_Id" });
            DropTable("dbo.TechnicalDetails");
            DropTable("dbo.StackOverflowInfoes");
            DropTable("dbo.Respondents");
            DropTable("dbo.RespondentDetails");
            DropTable("dbo.JobInfoes");
            DropTable("dbo.Influences");
            DropTable("dbo.ImportantHirings");
            DropTable("dbo.HaveWorkedAndWants");
            DropTable("dbo.ExperienceLevels");
            DropTable("dbo.ExCoders");
            DropTable("dbo.Equipments");
            DropTable("dbo.Employments");
            DropTable("dbo.Educations");
            DropTable("dbo.Countries");
            DropTable("dbo.CompanySizes");
            DropTable("dbo.Assesses");
        }
    }
}
