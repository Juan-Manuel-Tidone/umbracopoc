using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoSample.Models
{
    public class NavigationLinkInfo
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewWindow { get; set; }
        public string Target
        {
            get => NewWindow ? "_blank" : null;
        }
        public string Title { get; set; }

        public NavigationLinkInfo()
        {
                    
        }

        public NavigationLinkInfo(string url, string text = null, bool newWindow = false, string title = null)
        {
            Text = text;
            Url = url;
            NewWindow = newWindow;
            Title = title;
        }
    }

    public class NavigationList
    {

        public string Text { get; set; }
        public NavigationLinkInfo Link { get; set; }
        public List<NavigationList> NavItems { get; set; }
        public bool HasSubNavigation => NavItems != null && NavItems.Any();

        public NavigationList()
        {
                
        }

        public NavigationList(NavigationLinkInfo link)
        {
            Link = link;
        }
    }
}