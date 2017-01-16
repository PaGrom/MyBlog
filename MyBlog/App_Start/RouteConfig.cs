using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Blog", action = "Posts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Category",
                url: "Category/{category}",
                defaults: new { controller = "Blog", action = "Category" }
            );

            routes.MapRoute(
                name: "Tag",
                url: "Tag/{tag}",
                defaults: new { controller = "Blog", action = "Tag" }
            );

            routes.MapRoute(
                name: "Post",
                url: "Archive/{year}/{month}/{title}",
                defaults: new { controller = "Blog", action = "Post" }
            );
        }
    }
}
