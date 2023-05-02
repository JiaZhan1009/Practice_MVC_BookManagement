using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Course4_Net_MVC
{
    //public class MvcApplication : System.Web.HttpApplication
    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication
    {
        //這是 ASP.NET MVC 專案中 Global.asax.cs 檔案的內容。該檔案定義了 MvcApplication 類別，它繼承自 System.Web.HttpApplication 類別。

        //MvcApplication 類別中定義了一個名為 Application_Start 的方法。該方法在應用程式啟動時被調用一次，用於執行應用程式的初始化工作。

        // 在應用程式啟動時執行，初始化所有設定、路由和捆綁包設定
        protected void Application_Start()
        {
            // 註冊專案中定義的所有區域(Area)。區域是一種組織複雜專案的方式，它允許您將不同功能模組的控制器、視圖和模型分組在不同的區域中。
            AreaRegistration.RegisterAllAreas();

            // 註冊全局篩選器。篩選器是一種可以在執行控制器動作之前或之後運行的程式碼，它可以用於執行授權、錯誤處理、日誌記錄等操作。
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // 註冊路由。路由是一種將 URL 映射到控制器動作的方式。您可以在 RouteConfig.cs 檔案中定義路由規則。
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // 註冊捆綁包(Bundle)。捆綁包是一種將多個 CSS 或 JavaScript 檔案合併成一個檔案的方式，它可以減少 HTTP 請求的數量，提高頁面加載速度。
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

}

