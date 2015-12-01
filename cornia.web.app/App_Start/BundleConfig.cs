using System.Web;
using System.Web.Optimization;

namespace cornia.web.app
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Asset/Style/Pack").Include(
                   "~/Asset/Style/Bootstrap.css",
                   "~/Asset/Style/Bootstrap-Theme.css",
                   "~/Asset/Style/Kendo-Common.css",
                   "~/Asset/Style/Kendo-Silver.css",
                   "~/Asset/Style/Kendo-Silver-Mobile.css",
                   "~/Asset/Style/Kendo-Dataviz.css",
                   "~/Asset/Style/Kendo-Dataviz-Silver.css",
                   "~/Asset/Font/FontAwesome.css",
                   "~/Asset/Style/Style.css",
                   "~/Asset/Style/Style-Responsive.css"
                   ));

            bundles.Add(new ScriptBundle("~/Asset/Script/Pack").Include(
                      "~/Asset/Script/jQuery.js",
                      "~/Asset/Script/Angular.js",
                      "~/Asset/Script/Bootstrap.js",
                      "~/Asset/Script/Kendo.js",
                      //"~/Asset/Script/Kendo-Culture-TR.js",
                      //"~/Asset/Script/Kendo-Messages-TR.js",
                      "~/Asset/Script/Spin.js",
                      "~/Asset/Script/Design.js",
                      "~/Asset/Script/Script.js"
                      ));


            bundles.Add(new ScriptBundle("~/Asset/Complete/Pack").Include(
                      "~/Asset/Script/Complete.js",
                      "~/Asset/Script/JSNLog.js"
                      ));

            bundles.Add(new StyleBundle("~/Asset/Print/Pack").Include(
                      "~/Asset/Style/Print.css"
                      ));
        }
    }
}
