using System.Collections.Generic;

namespace StackOverflowSurvey.Service
{
    public class RespondentsCreationResult
    {
        public string FileName { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}