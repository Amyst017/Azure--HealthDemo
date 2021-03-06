﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_Error() {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext != null) {
                RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
                /* when the request is ajax the system can automatically handle a mistake with a JSON response. then overwrites the default response */
                if (requestContext.HttpContext.Request.IsAjaxRequest()) {
                    httpContext.Response.Clear();
                    string controllerName = requestContext.RouteData.GetRequiredString("controller");
                    IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
                    IController controller = factory.CreateController(requestContext, controllerName);
                    ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);

                    JsonResult jsonResult = new JsonResult();
                    jsonResult.Data = new { success = false, serverError = "500" };
                    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    jsonResult.ExecuteResult(controllerContext);
                    httpContext.Response.End();
                }
                else {
                    // last chance to intercept error
                    int err = -1;
                    HttpException e = (HttpException)Server.GetLastError();
                    if (e != null) {
                        err = e.GetHttpCode();
                    };
                    switch(err){
                        case 403: 
                            var url = string.Format("~/Error/Index/{0}", err);
                            httpContext.Response.Redirect(url);
                            break;
                        case 404:
                            httpContext.Response.Redirect("~/Error/NotFound"); 
                            break;
                        case 500:
                            break;
                    }  
                }
            }
        }

    }
}
