using System.Web;
using System.Web.Optimization;

namespace WebEpione
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include(

               "~/Content/js/jquery-2.2.4.min.js",
             "~/Content/js/common_scripts.min.js",
             "~/Content/js/functions.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/menu.css",
                      "~/Content/css/vendors.css",
                       "~/Content/css/tables.css",
                       "~/Content/css/blog.css",
                      "~/Content/css/icon_fonts/css/all_icons_min.css",
                      "~/Content/css/style.css"));
        }
    }
}
