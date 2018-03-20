using System.Collections.Generic;
using System.Web;

namespace StackOverflowSurvey.Service
{
    public static class RespondentsLoader
    {
        public static List<PostedFile> RespondentFiles { get; set; } = new List<PostedFile>();

        public static IEnumerable<PostedFile> LoadRespondentFiles(HttpFileCollection fileCollection)
        {
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile file = fileCollection.Get(i);
                PostedFile postedFile = new PostedFile { FileName = file.FileName, InputStream = file.InputStream };
                RespondentFiles.Add(postedFile);
                yield return postedFile;
            }
        }
    }
}