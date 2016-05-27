using System;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(IntroMvcDemo.App_Start.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(IntroMvcDemo.App_Start.WindsorActivator), "Shutdown")]

namespace IntroMvcDemo.App_Start
{
    public static class WindsorActivator
    {
        static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();
        }
        
        public static void Shutdown()
        {
            if (bootstrapper != null)
                bootstrapper.Dispose();
        }
    }
}