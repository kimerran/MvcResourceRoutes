MvcResourceRoutes
=================

Extension helpers for ASP.NET MVC RouteCollection.

This is an ASP.NET MVC implementation of Laravel's Resource Controller (http://laravel.com/docs/controllers#resource-controllers)

### Usage
1\. Include the library in Resources and add this *using* statement in __RouteConfig.cs__
```csharp
using Kimerran.MvcResourceRoutes;

```
  
  
2\. Register resource routes by using this extension method. For example, we want to create resource routes for *Book*
```csharp
routes.RegisterResourceRoutes("Book");
```

3\. After registration, you will have the following routes added to your RouteCollection

Verb          | Path          | Action  | Common usage
------------- | ------------- | ------- | ------------
GET           | /book         | Index   | Returns list of books
GET           | /book/new     | New     | Returns form for adding a new book
POST          | /book         | Create  | Adds a new book
GET           | /book/28/edit | Edit    | Returns a form for editing a book
GET           | /book/28      | Show    | Shows existing book information
PUT           | /book/28      | Update  | Updates existing book
DELETE        | /book/28      | Delete  | Deletes existing book

