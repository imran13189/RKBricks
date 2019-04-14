using System.Web;
using System.Web.Optimization;

namespace RKBrick
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquerymain").Include(
                        "~/Scripts/js/jquery.1.11.1.js",
                          "~/Scripts/js/jquery.dataTables.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/js/bootstrap.js",
                         "~/Scripts/js/SmoothScroll.js",
                         "~/Scripts/js/nivo-lightbox.js",
                         "~/Scripts/js/jqBootstrapValidation.js",
                         //"~/Scripts/js/contact_me.js",
                         "~/Scripts/js/main.js"
                        ));

           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/fonts/font-awesome/css/font-awesome.css",
                      "~/Content/css/style.css",
                      "~/Content/css/nivo-lightbox/nivo-lightbox.css",
                      "~/Content/css/nivo-lightbox/default.css",
                       "~/Content/css/jquery.dataTables.min.css"

                     ));
        }
    }
}
