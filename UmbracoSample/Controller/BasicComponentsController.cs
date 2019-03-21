﻿using System;
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
            return PartialView("~/Views/Partials/BasicComponents/Banner.cshtml");
        }

        public ActionResult TitleAndContent()
        {
            return PartialView("~/Views/Partials/BasicComponents/TitleAndContent.cshtml");
        }

        public ActionResult GenericContent()
        {
            return PartialView("~/Views/Partials/BasicComponents/GenericContent.cshtml");
        }


        public ActionResult RenderTitleAndImage()
        {
            var list = CurrentPage.DescendantsOrSelf().Where(x => x.IsDocumentType("titleImage"));
            
            
            return PartialView("~/Views/Partials/BasicComponents/TitleImage.cshtml", list);
        }
    }
}