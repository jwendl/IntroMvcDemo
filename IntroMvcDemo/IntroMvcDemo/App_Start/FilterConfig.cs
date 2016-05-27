using IntroMvcDemo.Common;
using System.Web.Mvc;

namespace IntroMvcDemo
{
    public sealed class FilterConfig
    {
        private FilterConfig()
        {

        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            Arg.IsNotNull(() => filters);

            filters.Add(new HandleErrorAttribute());
        }
    }
}
