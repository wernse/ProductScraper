using System.Web;
using System.Web.Optimization;

namespace angularJS
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/coreApp")
                .Include("~/App/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/other")
                .IncludeDirectory("~/App/Landing", "*.js",true));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
