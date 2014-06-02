using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kimerran.MvcResourceRoutes
{
    public static class RouteCollectionExtension
    {
        /// <summary>
        /// Create routes for a resource similar to Laravel's Resource Controllers
        /// http://laravel.com/docs/controllers#resource-controllers
        /// </summary>
        /// <param name="routes">The route collection</param>
        /// <param name="resourceName"></param>
        public static void RegisterResourceRoutes(this RouteCollection routes, string resourceName)
        {          
            // Example: resourceName = Book

            // [GET] /book
            routes.MapRoute(resourceName + "@index",
                resourceName,
                new { controller = resourceName, action = "Index", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [GET] /book/create
            routes.MapRoute(resourceName + "@create",
                resourceName + "/create",
                new { controller = resourceName, action = "Create", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [POST] /book
            routes.MapRoute(resourceName + "@store",
                resourceName,
                new { controller = resourceName, action = "Store", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("POST") }
            );

            // [GET] /book/28/edit
            routes.MapRoute(resourceName + "@edit",
                resourceName + "/{id}/edit",
                new { controller = resourceName, action = "Edit", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [GET] /book/28
            routes.MapRoute(resourceName + "@show",
                resourceName + "/{id}",
                new { controller = resourceName, action = "Show", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [PUT] /book/28
            routes.MapRoute(resourceName + "@update",
                resourceName + "/{id}",
                new { controller = resourceName, action = "Update", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("PUT") }
            );

            // [DELETE] /book/28
            routes.MapRoute(resourceName + "@delete",
                resourceName + "/{id}",
                new { controller = resourceName, action = "Delete", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("DELETE") }
            );
        }
   
    }
}
