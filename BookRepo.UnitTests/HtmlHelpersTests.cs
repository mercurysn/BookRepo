using System.Web.Mvc;
using BookRepo.Helpers;
using NUnit.Framework;

namespace BookRepo.UnitTests
{
    [TestFixture]
    public class HtmlHelpersTests
    {
        [Test]
        public void Test_HtmlActionLinkWithIcon_ReturnCorrectString()
        {
            const string linkText = "Book Library";
            const string actionName = "Index";
            const string controllerLink = "Library";

            //HtmlHelpers.ActionLinkWithIcon(linkText, actionName, controllerLink, "aa");
        }
    }
}
