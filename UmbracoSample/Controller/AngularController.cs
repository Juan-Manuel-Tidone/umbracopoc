using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace UmbracoSample.Controller
{
    public class AngularController : SurfaceController
    {
        // GET: Angular
        public ActionResult AppComponent()
        {
            //Sample --> way to get the Home Item
            //var home = Umbraco.ContentAtRoot().FirstOrDefault();

            var xpath = string.Format("id({0})//{1}[@isDoc and @nodeName = '{2}']",1055, "genericPage", "Angular Page");
            var currentPage = Umbraco.ContentSingleAtXPath(xpath);
            
            return Json(
                new
                {
                    message = RenderRazorViewToString(ControllerContext,
                        "~/Views/Partials/AngularComponents/appComponent.cshtml", currentPage)
                }, JsonRequestBehavior.AllowGet);


        }

        public static string RenderRazorViewToString(ControllerContext controllerContext, string viewName, object model)
        {
            controllerContext.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                ViewResult.View.Render(ViewContext, sw);
                ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}