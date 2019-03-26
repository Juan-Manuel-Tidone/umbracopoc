using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace UmbracoSample.Controller
{
    public class BasicComponentsController : SurfaceController
    {

        public ActionResult Banner()
        {
            return PartialView("~/Views/Partials/BasicComponents/Banner.cshtml", CurrentPage);
        }

        public ActionResult TitleAndContent()
        {
            //IPublishedContent should be pass a the Model
            return PartialView("~/Views/Partials/BasicComponents/TitleAndContent.cshtml", CurrentPage);
        }

        public ActionResult GenericContent()
        {
            return PartialView("~/Views/Partials/BasicComponents/GenericContent.cshtml", CurrentPage);
        }


        public ActionResult RenderTitleAndImage()
        {
            var list = CurrentPage.DescendantsOrSelf().Where(x => x.IsDocumentType("titleImage"));
            
            
            return PartialView("~/Views/Partials/BasicComponents/TitleImage.cshtml", list);
        }
    }
}