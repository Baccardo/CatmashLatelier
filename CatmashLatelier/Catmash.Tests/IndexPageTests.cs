using Catmash.Application.Pages;
using Catmash.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catmash.Tests
{
    [TestFixture]
    public class IndexPageTests
    {
        [Test]
        public void TestVoteIncrementsOnPostPage()
        {
            var imagesList = new List<Image> { new Image { Id = "1" }, new Image { Id = "2" }, new Image { Id = "3" } };
            var indexPage = new IndexModel(Mock.Of<IImageDirectory>(i => i.Images == imagesList));
            indexPage.OnPostVote(imagesList[0].Id);
            Assert.AreEqual(1, imagesList[0].Votes);
        }
    }
}
