using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kimerran.MvcResourceRoutes
{
    /*
     * Creates the following routes similar to Laravel / Ruby on Rails conventions 
     * For example, we have a Books collection
     * ---------------------------------------------------------------------------
     * VERB     PATH                CONTROLLER.ACTION           DESCRIPTION
     * ---------------------------------------------------------------------------
     * GET      /books              BooksController.Index       
     * GET      /books/new          BooksController.New
     * POST     /books              BooksController.Create
     * GET      /books/{id}         BooksController.Show
     * GET      /books/{id}/edit    BooksController.Edit
     * PUT      /books/{id}         BooksController.Update
     * DELETE   /books/{id}         BooksController.Destroy
     * 
     */
    public static class MvcResourceRoutes
    {
        /// <summary>
        /// Default Action names. Override using the [SetActionName] method.
        /// </summary>
        private static Dictionary<string, string> _routeNames = new Dictionary<string, string>
        {
            {"index", "Index"},
            {"new", "New"},
            {"create", "Create"},
            {"show", "Show"},
            {"edit", "Edit"},
            {"update", "Update"},
            {"desctroy", "Destroy"}
        };
        
        /// <summary>
        /// Create routes for a resource
        /// Laravel Doc: http://laravel.com/docs/controllers#resource-controllers
        /// RoR Doc: http://guides.rubyonrails.org/routing.html
        /// </summary>
        /// <param name="routes">The route collection</param>
        /// <param name="resourceName"></param>
         /// <param name="pathName"></param>
        public static void RegisterResourceRoutes(this RouteCollection routes, string resourceName, string pathName = "")
        {
            // Example: resourceName = Books

            if (string.IsNullOrEmpty(pathName)) pathName = resourceName;


            // [GET] /books
            routes.MapRoute(resourceName + "@index",
                pathName,
                new { controller = resourceName, action = _routeNames["index"]},
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [GET] /books/create
            routes.MapRoute(resourceName + "@new",
                pathName + "/new",
                new { controller = resourceName, action = _routeNames["new"] },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [POST] /books
            routes.MapRoute(resourceName + "@create",
                pathName,
                new { controller = resourceName, action = _routeNames["create"] },
                new { httpMethod = new HttpMethodConstraint("POST") }
            );

            // [GET] /books/28
            routes.MapRoute(resourceName + "@show",
                pathName + "/{id}",
                new { controller = resourceName, action = _routeNames["show"] },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [GET] /books/28/edit
            routes.MapRoute(resourceName + "@edit",
                pathName + "/{id}/edit",
                new { controller = resourceName, action = _routeNames["edit"] },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // [PUT] /books/28
            routes.MapRoute(resourceName + "@update",
                pathName + "/{id}",
                new { controller = resourceName, action = _routeNames["update"] },
                new { httpMethod = new HttpMethodConstraint("PUT") }
            );

            // [DELETE] /books/28
            routes.MapRoute(resourceName + "@destroy",
                pathName + "/{id}",
                new { controller = resourceName, action = _routeNames["destroy"] },
                new { httpMethod = new HttpMethodConstraint("DELETE") }
            );
        }

        /// <summary>
        /// Overrides the default action names
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="newName"></param>
        public static void SetActionName(string actionName, string newName)
        {
            if (!_routeNames.ContainsKey(actionName)) 
                throw new Exception("Action name should be one of the following: index, new, create, show, edit, update, destroy");

            _routeNames.Remove(actionName);
            _routeNames.Add(actionName, newName);
        }


    }
}
