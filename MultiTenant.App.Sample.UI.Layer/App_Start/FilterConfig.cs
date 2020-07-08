using System.Web;
using System.Web.Mvc;

namespace MultiTenant.App.Sample.UI.Layer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
