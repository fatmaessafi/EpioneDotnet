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
             "~/Content/js/bootstrap-datepicker.js",
             "~/Content/js/infoxbox.js",
             "~/Content/js/jquery.cookiebar.js",
             "~/Content/js/jquery.selectbox-0.2.js",
             "~/Content/js/map_listing.js",
             "~/Content/js/mapmarker.jquery.js",
             "~/Content/js/mapmarker_contacts_func.js",
             "~/Content/js/modernizr.js",
             "~/Content/js/modernizr_tables.js",
             "~/Content/js/pw_strenght.js",
             "~/Content/js/tables_func.js",
             "~/Content/js/tables_func_2.js",
             "~/Content/js/video_header.js",           
             "~/Content/js/functions.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/date_picker.css",
                      "~/Content/css/menu.css",
                      "~/Content/css/vendors.css",
                      "~/Content/css/icon_fonts/css/all_icons_min.css",
                      "~/Content/css/style.css"));
        }
    }
}
