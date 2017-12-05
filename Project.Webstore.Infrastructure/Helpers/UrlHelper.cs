using System.Web;

namespace Project.Webstore.Infrastructure.Helpers
{
    public static class UrlHelper
    {
        public static string Resolve(string resource)
        {
            var httpRequest = HttpContext.Current.Request;

            return string.Format("{0}://{1}{2}{3}",
                httpRequest.Url.Scheme,
                httpRequest.ServerVariables["HTTP_HOST"], 
                (httpRequest.ApplicationPath.Equals("/")) ? string.Empty : httpRequest.ApplicationPath,
                resource);
        }
    }
}
