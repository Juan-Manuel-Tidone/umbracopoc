using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace UmbracoSample.Controller
{
    public class HomeController : SurfaceController
    {

        public ActionResult Variant()
        {

            // get a reference to the services
            var campaign = Request["campaingId"];

            switch (campaign)
            {
                case "1002":
                    return PartialView("~/Views/Partials/Variations/Variation1.cshtml");
                case "2002":
                    return PartialView("~/Views/Partials/Variations/Variation2.cshtml");
                default:
                    return PartialView("~/Views/Partials/Variations/Variation1.cshtml");
            }

            //return PartialView("~/Views/Partials/BasicComponents/Banner.cshtml");
        }


    }
}