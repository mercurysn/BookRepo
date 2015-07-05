using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BookRepo.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString ActionLinkWithIcon(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, string iconClass)
        {
            var link = htmlHelper.ActionLink(linkText, actionName, controllerName);

            return MvcHtmlString.Create(link.ToString().Replace(linkText, string.Format("<i class=\"{0}\"></i>{1}", iconClass, linkText)));
        }
    }
}