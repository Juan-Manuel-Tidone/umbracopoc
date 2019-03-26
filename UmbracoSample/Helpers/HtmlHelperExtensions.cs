using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
//using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace UmbracoSample.Helpers
{
    public static class HtmlHelperExtensions
    {

        #region Nested Content Extensions

        /// <summary>
        /// MVC Html helper extension for rendering a single Nested Content object (type is IPublishedContent). Use viewDataDictionary to pass in additional data to the view.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="contentModel"></param>
        /// <param name="viewDataDictionary"></param>
        /// <returns></returns>
        public static IHtmlString RenderNestedContentPartials(this HtmlHelper htmlHelper, IPublishedContent contentModel, ViewDataDictionary viewDataDictionary = null)
        {
            return htmlHelper.RenderNCPartials(new IPublishedContent[] { contentModel }, viewDataDictionary);
        }

        /// <summary>
        /// MVC Html helper extension for rendering a list of Nested Content objects (type is IPublishedContent). Use viewDataDictionary to pass in additional data to the view.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="contentModels"></param>
        /// <param name="viewDataDictionary"></param>
        /// <returns></returns>
        public static IHtmlString RenderNestedContentPartials(this HtmlHelper htmlHelper, IEnumerable<IPublishedElement> contentModels, ViewDataDictionary viewDataDictionary = null)
        {
            return htmlHelper.RenderNCPartials(contentModels, viewDataDictionary);
        }

        private static IHtmlString RenderNCPartials(this HtmlHelper htmlHelper, IEnumerable<IPublishedElement> contentModels, ViewDataDictionary viewDataDictionary)
        {
            if (contentModels == null || HttpContext.Current == null)
            {
                return new HtmlString("");
            }

            StringBuilder result = new StringBuilder();

            foreach (IPublishedElement content in contentModels)
            {
                TypeHelper tHelper = new TypeHelper();

                var pathToPartials = "~/Views/Partials/NestedContent/";
                var partial = string.Format("{0}{1}.cshtml", pathToPartials, content.ContentType.Alias);
                
                result.Append(htmlHelper.Partial(partial, content, viewDataDictionary).ToString());
            }

            return new HtmlString(result.ToString());
        }

        #endregion
    }
}