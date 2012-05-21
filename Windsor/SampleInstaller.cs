using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Windsor
{
    public class SampleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var allInterfaces = Classes.FromThisAssembly().
                Pick().
                WithService.AllInterfaces().
                LifestyleTransient();

            container.Register(allInterfaces);
        }
    }
}