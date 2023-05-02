using System.Web;
using System.Web.Optimization;

namespace Course4_Net_MVC
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
            //            "~/Scripts/kendo.all.min.js"));



            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        //    bundles.Add(new StyleBundle("~/Content/kendo-common").Include(
        //            "~/Content/kendo.common-material.min.css"));
        //    bundles.Add(new StyleBundle("~/Content/kendo-material").Include(
        //"~/Content/kendo.material-main.min.css"));
        }

        //這部分程式碼是ASP.NET MVC中用來註冊網頁資源捆綁（Bundle）的方法，
        //用來整合CSS和JavaScript等前端資源，以提高網頁載入速度。

        //RegisterBundles方法接受一個BundleCollection物件作為參數，
        //這個物件可以用來管理和註冊不同的捆綁。在這個方法裡，
        //我們可以看到透過bundles.Add方法新增了四個捆綁：

        //jquery：包含了jQuery函式庫的js檔案。
        //jqueryval：包含了jQuery驗證插件的js檔案。
        //modernizr：包含了Modernizr檢查器的js檔案，用來檢查瀏覽器支援的HTML5和CSS3特性。
        //bootstrap：包含了Bootstrap框架的js檔案和css檔案。

        //其中，ScriptBundle是用來捆綁JavaScript檔案的，StyleBundle是用來捆綁CSS檔案的。
        //透過這些捆綁，可以使網頁載入速度更快，也更易於管理前端資源。
    }
}
