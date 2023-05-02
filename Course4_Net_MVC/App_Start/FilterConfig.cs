using System.Web;
using System.Web.Mvc;

namespace Course4_Net_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        //這段程式碼是在 ASP.NET MVC 應用中註冊全局過濾器的方法。
        //過濾器是指在執行 Action 方法前或執行 Action 方法後執行的某些代碼。
        //ASP.NET MVC 應用支持多種不同類型的過濾器，例如授權過濾器、輸出快取過濾器、動作過濾器等等。

        //在這個方法中，我們使用 GlobalFilterCollection 類型來維護全局過濾器的集合。
        //全局過濾器是指在整個應用中都會執行的過濾器。
        //我們可以使用 Add 方法向這個集合中添加一個或多個過濾器。

        //在這個例子中，我們向全局過濾器集合中添加了一個 HandleErrorAttribute 過濾器。
        //這個過濾器用於處理在執行 Action 方法時發生的未處理例外，並將其轉換為一個友好的錯誤頁面。
        //通常，我們會將這個過濾器添加到全局範圍中，以便在整個應用中都能夠處理未處理例外。
    }
}
