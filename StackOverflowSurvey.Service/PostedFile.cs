namespace StackOverflowSurvey.Service
{
    using System.IO;

    public class PostedFile
    {
        public string FileName { get; set; }

        public Stream InputStream { get; set; }
    }
}