using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IntroMvcDemo.Common;
using IntroMvcDemo.DataAccess.Interfaces;
using System.Data.Entity;

namespace IntroMvcDemo.Installers
{
    public class RepositoriesInstaller
        : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Arg.IsNotNull(() => container);
            var dataAccessAssemblyName = "IntroMvcDemo.DataAccess";

            container.Register(Classes.FromAssemblyNamed(dataAccessAssemblyName).BasedOn(typeof(DbContext)).WithService.Base().LifestylePerWebRequest());
            container.Register(Classes.FromAssemblyNamed(dataAccessAssemblyName).BasedOn(typeof(IDataRepository<>)).WithService.Base().LifestylePerWebRequest());
        }
    }
}
