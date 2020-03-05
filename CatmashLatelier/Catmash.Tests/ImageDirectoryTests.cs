using Catmash.Data;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;

namespace Catmash.Tests
{
    [TestFixture]
    public class ImageDirectoryTests
    {
        [Test]
        public void TestImageDirectoryWithValidUrl()
        {
            var imageDirectory = new ImageDirectory(Mock.Of<IConfiguration>(c => c["CatsUrl"] == "https://latelier.co/data/cats.json"));
            var images = imageDirectory.Images;
            Assert.IsNotEmpty(images);
        }

        [Test]
        public void TestImageDirectoryWithoutUrl()
        {
            Assert.Throws<AggregateException>(() => new ImageDirectory(Mock.Of<IConfiguration>()));
        }
    }
}
