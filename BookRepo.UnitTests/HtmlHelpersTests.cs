using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        [Test]
        public void SandBox()
        {
            List<SandboxBook> bookList = new List<SandboxBook>
            {
                new SandboxBook
                {
                    DateRead = new DateTime(2015, 8, 20),
                    Pages = 10
                },
                new SandboxBook
                {
                    DateRead = new DateTime(2015, 9, 20),
                    Pages = 10
                },
                new SandboxBook
                {
                    DateRead = new DateTime(2015, 8, 1),
                    Pages = 10
                }
            };

            var result = bookList.GroupBy(b => new { b.DateRead.Value.Year, b.DateRead.Value.Month } ).ToList();

            Assert.AreEqual(new {Year = 2015, Month = 8}, result[0].Key);
            Assert.AreEqual(new { Year = 2015, Month = 9 }, result[1].Key);

            Assert.AreEqual(20, result[0].Sum(b => b.Pages));
            Assert.AreEqual(10, result[1].Sum(b => b.Pages));

            foreach (var bookGroup in result)
            {
                foreach (var sandboxBook in bookGroup)
                {
                    
                }
            }
        }
    }

    public class SandboxBook
    {
        public DateTime? DateRead { get; set; }
        public int Pages { get; set; }
    }
}
