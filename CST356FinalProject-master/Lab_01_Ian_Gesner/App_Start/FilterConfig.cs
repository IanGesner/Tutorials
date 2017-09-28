using System.Web;
using System.Web.Mvc;

namespace Lab_01_Ian_Gesner
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
