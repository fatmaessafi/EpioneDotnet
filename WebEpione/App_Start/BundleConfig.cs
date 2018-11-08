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


            bundles.Add(new ScriptBundle("~/Content/adminjs").Include(

               "~/Content/admin_section/vendor/jquery/jquery.min.js",
               "~/Content/admin_section/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/admin_section/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/admin_section/vendor/chart.js/Chart.js",
                "~/Content/admin_section/vendor/datatables/jquery.dataTables.js",
                "~/Content/admin_section/vendor/datatables/dataTables.bootstrap4.js",
                "~/Content/admin_section/vendor/jquery.selectbox-0.2.js",
                "~/Content/admin_section/vendor/retina-replace.min.js",
                "~/Content/admin_section/vendor/jquery.magnific-popup.min.js",
                "~/Content/admin_section/js/admin.js",
                 "~/Content/admin_section/js/admin-charts.js",
                  "~/Content/admin_section/vendor/dropzone.min.js"


            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/menu.css",
                      "~/Content/css/vendors.css",
                      "~/Content/css/icon_fonts/css/all_icons_min.css",
                      "~/Content/css/style.css"));
        }
    }
}
