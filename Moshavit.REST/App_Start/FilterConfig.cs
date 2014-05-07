using System.Web;
using System.Web.Mvc;
using Moshavit.REST.Controllers;

namespace Moshavit.REST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}