using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StackOverflowSurvey.Web.Startup))]

namespace StackOverflowSurvey.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app){
           
        }
    }
}
