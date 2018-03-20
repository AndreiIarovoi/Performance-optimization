using System.Web.Http.Dependencies;
using Ninject;

namespace StackOverflowSurvey.Web
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }

        private void AddBindings()
        {
            kernel.Load("StackOverflowSurvey.*.dll");
        }
    }
}