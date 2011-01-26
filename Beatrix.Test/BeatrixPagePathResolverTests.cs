using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Beatrix.Pages;
using Beatrix.Controllers;

namespace Beatrix.Test
{
    [TestFixture]
    public class BeatrixPagePathResolverTests
    {
        [Test]
        public void When_called_with_a_page_without_ControllerAttribute_the_correct_url_is_resolved()
        {
            var page = new TestPage { Url = "/foo/bar" };

            var resolver = new BeatrixPagePathResolver();

            Assert.AreEqual("/test", resolver.ResolvePath(page, "/foo/bar"));
            Assert.AreEqual("/test/baz", resolver.ResolvePath(page, "/foo/bar/baz"));
            Assert.AreEqual("/test/baz/id", resolver.ResolvePath(page, "/foo/bar/baz/id"));
        }

        [Test]
        public void When_called_with_a_page_with_ControllerAttribute_the_correct_url_is_resolved()
        {
            var page = new TestPage2 { Url = "/foo/bar" };

            var resolver = new BeatrixPagePathResolver();

            Assert.AreEqual("/attribute", resolver.ResolvePath(page, "/foo/bar"));
            Assert.AreEqual("/attribute/baz", resolver.ResolvePath(page, "/foo/bar/baz"));
            Assert.AreEqual("/attribute/baz/id", resolver.ResolvePath(page, "/foo/bar/baz/id"));
        }
    }

    class TestPage : BeatrixPage
    { }

    [Controller(typeof(AttributeController))]
    class TestPage2 : BeatrixPage
    { }

    class AttributeController : BeatrixController<TestPage2>
    {
        public AttributeController(TestPage2 page) : base(page) { }
    }
}
