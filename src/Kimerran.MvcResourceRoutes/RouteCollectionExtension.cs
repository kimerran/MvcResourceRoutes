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
        public static void RegisterResourceRoutes(this RouteCollection routes, string resourceName, string pathName = "")
        {
            // Example: resourceName = Book

            if (string.IsNullOrEmpty(pathName)) pathName = resourceName;


            // [GET] /book
            routes.MapRoute(resourceName + "@index",
                pathName,
                new { controller = resourceName, action = "Index" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [GET] /book/create
            routes.MapRoute(resourceName + "@create",
                pathName + "/create",
                new { controller = resourceName, action = "Create" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [POST] /book
            routes.MapRoute(resourceName + "@store",
                pathName,
                new { controller = resourceName, action = "Store" },
                new { httpMethod = new HttpMethodConstraint("POST") }
            );

            // [GET] /book/28/edit
            routes.MapRoute(resourceName + "@edit",
                pathName + "/{id}/edit",
                new { controller = resourceName, action = "Edit" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [GET] /book/28
            routes.MapRoute(resourceName + "@show",
                pathName + "/{id}",
                new { controller = resourceName, action = "Show" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [PUT] /book/28
            routes.MapRoute(resourceName + "@update",
                pathName + "/{id}",
                new { controller = resourceName, action = "Update" },
                new { httpMethod = new HttpMethodConstraint("PUT") }
            );

            // [DELETE] /book/28
            routes.MapRoute(resourceName + "@delete",
                pathName + "/{id}",
                new { controller = resourceName, action = "Delete" },
                new { httpMethod = new HttpMethodConstraint("DELETE") }
            );
        }

    }
}
