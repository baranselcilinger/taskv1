using System.Web.Optimization;

namespace TaskSchedule
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                    "~/Scripts/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                    "~/Scripts/raphael.min.js",
                    "~/Scripts/morris.min.js",
                    "~/Scripts/jquery.sparkline.min.js",
                    "~/Scripts/jquery-jvectormap-1.2.2.min.js",
                    "~/Scripts/jquery-jvectormap-world-mill-en.js",
                    "~/Scripts/jquery.knob.min.js",
                    "~/Scripts/moment/min/moment.min.js",
                    "~/Scripts/daterangepicker.js",
                    "~/Scripts/bootstrap-datepicker.min.js",
                    "~/Scripts/bootstrap3-wysihtml5.all.min.js",
                    "~/Scripts/jquery.slimscroll.min.js",
                    "~/Scripts/fastclick.js",
                    "~/Scripts/jquery.dataTables.js",
                    "~/Scripts/adminlte.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap/bootstrap.min.css",
                    "~/fonts/font-awesome/css/font-awesome.min.css",
                    "~/Content/Ionicons/css/ionicons.min.css",
                    "~/Content/css/AdminLTE.min.css",
                    "~/Content/css/_all-skins.min.css",
                    "~/Content/plugins/morris.css",
                    "~/Content/plugins/jquery-jvectormap.css",
                    "~/Content/plugins/bootstrap-datepicker.min.css",
                    "~/Content/plugins/daterangepicker.css",
                    "~/Content/plugins/bootstrap3-wysihtml5.min.css",
                    "~/Content/plugins/dataTables.bootstrap.css"));
        }
    }
}
