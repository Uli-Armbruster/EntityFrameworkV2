using System;
using System.IO;
using System.Reflection;

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace UAR.Infrastructure
{
    public class Bootstrapper : IDisposable
    {
        public Bootstrapper()
        {
            Container = new WindsorContainer();
        }

        public IWindsorContainer Container { get; private set; }

        public Bootstrapper RegisterComponents()
        {
            var appDomainDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var foundAssemblies = FromAssembly.InDirectory(new AssemblyFilter(appDomainDirectory));
            Container.Install(foundAssemblies);
            
            //Hack: Register container itself
            Container.Register(Component.For<IWindsorContainer>().Instance(Container));

            return this;
        }

        public Bootstrapper RegisterComponents(IWindsorInstaller[] installerForTestings)
        {
            Container.Install(installerForTestings);
            return this;
        }

        public Bootstrapper RunStartupConfiguration()
        {
            //not needed in this sample
            return this;
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public void Dispose()
        {
            if (Container != null)
            {
                Container.Dispose();
                Container = null;
            }
        }
    }
}