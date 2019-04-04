using System.Web;
using System.Web.Optimization;

namespace _360Ofset
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/cs").Include(
                      "~/wp-content/themes/goodspace_v1-07/stylesheet/skeleton-responsive.css",
                      "~/wp-content/themes/goodspace_v1-07/stylesheet/layout-responsive.css",
                      "~/wp-content/themes/goodspace_v1-07/style.css",
                      "~/wp-content/themes/goodspace_v1-07/style-customce52.css?ver=5.0.2",
                      "~/http://fonts.googleapis.com/css?family=Droid+Serif%3An%2Ci%2Cb%2Cbi%7C&amp;ver=5.0.2",
                      "~/wp-includes/css/dist/block-library/style.mince52.css?ver=5.0.2",
                      "~/wp-content/plugins/wp-whatsapp-chat/css/stylece52.css?ver=5.0.2",
                      "~/wp-content/plugins/jetpack/css/jetpack0899.css?ver=6.8.1",
                      "~/wp-content/themes/goodspace_v1-07/stylesheet/superfishce52.css?ver=5.0.2",
                      "~/wp-content/themes/goodspace_v1-07/stylesheet/prettyPhotoce52.css?ver=5.0.2",
                      "~/wp-content/themes/goodspace_v1-07/stylesheet/flexsliderce52.css?ver=5.0.2"));
            bundles.Add(new ScriptBundle("~/Content/js/pagetop").Include(
                "~/wp-includes/js/jquery/jqueryb8ff.js?ver=1.12.4",
                "~/wp-includes/js/jquery/jquery-migrate.min330a.js?ver=1.4.1",
                "~/wp-content/themes/goodspace_v1-07/javascript/jquery.fitvids5152.js?ver=1.0",
                        "~/wp-json/index.html"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
