using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using System.Globalization;
using System.Threading;
using System.Security.Principal;



namespace MvcDemo.Controllers
{
    public class BaseController : Controller
    {
        // language
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var execCulture = "fr-ca";
            var culture = CultureInfo.CreateSpecificCulture(execCulture);
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberGroupSeparator = " ";
            culture.NumberFormat.CurrencyDecimalSeparator = ".";
            culture.NumberFormat.CurrencyGroupSeparator = " ";
                
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            base.OnActionExecuted(filterContext);  
        }

        
        // don't forget Nuget ELMAH.MVC, will install global HandleError filter, that guarantees all unhandled errors are logged
        // http://localhost:64705/elmah

        //
        // Error handling : https://dusted.codes/demystifying-aspnet-mvc-5-error-pages-and-error-logging
        // This handling is useful when you need to distinguish your error handling between regular and AJAX requests on a controller level.

        protected override void OnException(ExceptionContext filterContext) {
            filterContext.ExceptionHandled = true;

            //// Redirect on error:  Error controler
            //filterContext.Result = RedirectToAction("Index", "Error");

            //// OR set the result without redirection:
            //filterContext.Result = new ViewResult
            //{
            //    ViewName = "~/Views/Error/Index.cshtml"
            //};

            Exception ex = filterContext.Exception;
            var model = new HandleErrorInfo(filterContext.Exception, filterContext.Controller.ToString(), filterContext.RouteData.Values["action"].ToString());
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                ViewData = new ViewDataDictionary(model)
            };

        }

        

    }


}


