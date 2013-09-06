using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(CssCdnFallback.App_Start.BootstrapBundleConfig), "RegisterBundles")]

namespace CssCdnFallback.App_Start
{
	public class BootstrapBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new StyleBundle("~/bundles/bootstrap", "http://netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css") 
			{
				CdnFallbackExpression = @"
					function (url) {
						var length = document.styleSheets.length;
						for (var i = 0; i < length; i++) {
							var sheet = document.styleSheets[i];
							if (sheet.href = url) {
								var rules = sheet.rules ? sheet.rules : sheet.cssRules;
								if (rules == null || rules.length == 0) {
									return false;
								}
							}
						}
					}('http://netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css')"
			}.Include("~/Content/bootstrap/bootstrap.css"));
			BundleTable.Bundles.UseCdn = true;
			BundleTable.EnableOptimizations = true;
		}
	}
}
