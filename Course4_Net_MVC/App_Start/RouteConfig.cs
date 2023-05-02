using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Course4_Net_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // 忽略掉所有 .axd 的 URL，不將其視為一個路由
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{page}",
                // 路由的預設值，如果 id = UrlParameter.Required 則設定為必要參數
                defaults: new { controller = "BookManagement", action = "Index", page = UrlParameter.Optional }
            );
        }

    }
}
