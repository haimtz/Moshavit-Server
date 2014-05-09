using System;
using System.Web.Optimization;

namespace Moshavit.REST.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundels(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(new ScriptBundle("~/scripts/vendor")
                .Include("~/scripts/jquery-{version}.js")
                .Include("~/scripts/jquery-{version}.intellisense.js")
                .Include("~/scripts/jquery.validate-vsdoc.js")
                .Include("~/scripts/bootstrap.min.js")
                .Include("~/scripts/knockout-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/ie10mobile.css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap-theme.min.css")
                .Include("~/Content/css/font-awesome.css")); // Must be first. IE10 mobile viewport fix


            var lessBundel = new Bundle("~/Assets/Style");
            lessBundel.Include("~/Assets/style.less");
            lessBundel.Transforms.Add(new LessTransform());
            lessBundel.Transforms.Add(new CssMinify());

            bundles.Add(lessBundel);
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            //ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}