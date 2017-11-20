using System.Web;
using System.Web.Optimization;

namespace HotelManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new ScriptBundle("~/bundles/jquerys").Include(
                     "~/Scripts/jquery-ui.js",
                     "~/Scripts/jquery.flexslider.js",
                     "~/Scripts/jquery.swipebox.min.js",
                     "~/Scripts/jqBootstrapValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-2.1.4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/easyresponse").Include(

                   "~/Scripts/easy-responsive-tab.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap-3.1.1.min.js",
                      "~/Scripts/contact_me.js",
                     "~/Scripts/easing.js",
                      "~/Scripts/main.js",
                      "~/Scripts/move-top.js",
                      "~/Scripts/responsiveslides.min.js"));

           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/chocolat.css",
                      "~/Content/easy-responsive-tabs.css",
                      "~/Content/flexslider.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/style.css"));
        }
    }
}
