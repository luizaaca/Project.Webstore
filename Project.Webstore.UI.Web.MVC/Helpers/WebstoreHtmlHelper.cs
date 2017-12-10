using System;
using System.Text;
using System.Web.Mvc;

namespace Project.Webstore.UI.Web.MVC.Helpers
{
    public static class WebstoreHtmlHelper
    {
        public static string BuildPageLinksFrom(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == currentPage)
                    tag.AddCssClass("selected");

                result.AppendLine(tag.ToString());
            }
            return result.ToString();
        }        
    }
}