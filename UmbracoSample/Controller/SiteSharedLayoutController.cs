using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using UmbracoSample.Models;


namespace UmbracoSample.Controller
{
    public class SiteSharedLayoutController:SurfaceController
    {
        public ActionResult Header()
        {
            List<NavigationList> nav = GetNavigation();
            return PartialView("~/Views/Partials/SharedLayout/Header.cshtml",nav);
        }

        public ActionResult Footer()
        {
            return PartialView("~/Views/Partials/SharedLayout/Footer.cshtml");
        }

        public List<NavigationList> GetNavigation()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]); //Get the Home Item
            IPublishedContent pageInfo = Umbraco.Content(pageId);

            //var nav = new List<NavigationList>
            //{
            //    new NavigationList(new NavigationLinkInfo(pageInfo.Url,pageInfo.Name))
            //};

            //Do not include the Home
            var nav = new List<NavigationList>();

            nav.AddRange(GetSubNav(pageInfo));

            return nav;
        }

        public List<NavigationList> GetSubNav(IPublishedContent page)
        {
            List<NavigationList> navList = null;

            //Exclude the Folders Doc Type
            var subPages = page.Children.Where(x => x.IsVisible() && !x.IsDocumentType("mMFolder"));
            if (subPages.Any())
            {
                navList = new List<NavigationList>();
                foreach (var subPage in subPages)
                {
                    var listItem = new NavigationList(new NavigationLinkInfo(subPage.Url, subPage.Name))
                    {
                        NavItems = GetSubNav(subPage)
                    };

                    navList.Add(listItem);
                }
            }

            return navList;

        }
    }
}