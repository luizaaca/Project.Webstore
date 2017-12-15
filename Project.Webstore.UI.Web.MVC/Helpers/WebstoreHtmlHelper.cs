using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace Project.Webstore.UI.Web.MVC.Helpers
{
    public static class WebstoreHtmlHelper
    {
        public static MvcHtmlString BuildPageLinksFrom(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
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
            return new MvcHtmlString(result.ToString());
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}