using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;

namespace IntroMvcDemo.Installers
{
    using Common;
    using Plumbing;
    using System;
    public class ControllersInstaller
        : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Arg.IsNotNull(() => container);

            container.Register(Classes.FromThisAssembly().BasedOn<IController>().If(c => c.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)).LifestyleTransient());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}