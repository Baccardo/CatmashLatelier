using Catmash.Business;
using Catmash.Data;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Catmash.Tests
{
    [TestFixture]
    public class ImageManagementTests
    {
        private ImageManagement imageManagement = new ImageManagement();

        [Test]
        public void TestApplyVoteWithExistantId()
        {
            var imagesList = new List<Image> { new Image { Id = "1" }, new Image { Id = "2" }, new Image { Id = "3" } };
            imageManagement.ApplyVote(imagesList, "1");
            Assert.AreEqual(1, imagesList[0].Votes);
            Assert.AreEqual(0, imagesList[1].Votes);
            Assert.AreEqual(0, imagesList[2].Votes);
        }

        [Test]
        public void TestApplyVoteWithImageListNull()
        {
            Assert.DoesNotThrow(() => imageManagement.ApplyVote(null, "1"));
        }

        [Test]
        public void TestApplyVoteWithNonExistantId()
        {
            var imagesList = new List<Image> { new Image { Id = "1" }, new Image { Id = "2" }, new Image { Id = "3" } };
            Assert.DoesNotThrow(() => imageManagement.ApplyVote(null, "4"));
            Assert.AreEqual(0, imagesList[0].Votes);
            Assert.AreEqual(0, imagesList[1].Votes);
            Assert.AreEqual(0, imagesList[2].Votes);
        }

        [Test]
        public void TestGetimagesRankedByVotesWithEmptyList()
        {
            var imagesList = new List<Image>();
            var imagesRankedByVotes = imageManagement.GetImagesRankedByVotes(imagesList);
            Assert.IsEmpty(imagesRankedByVotes);
        }

        [Test]
        public void TestGetimagesRankedByVotesWithNonEmptyList()
        {
            var imagesList = new List<Image> { new Image { Id = "1" }, new Image { Id = "2" }, new Image { Id = "3" } };
            imageManagement.ApplyVote(imagesList, "2");
            imageManagement.ApplyVote(imagesList, "2");
            imageManagement.ApplyVote(imagesList, "2");
            imageManagement.ApplyVote(imagesList, "3");
            imageManagement.ApplyVote(imagesList, "3");
            imageManagement.ApplyVote(imagesList, "1");
            var imagesRankedByVotes = imageManagement.GetImagesRankedByVotes(imagesList);
            Assert.AreEqual("2", imagesRankedByVotes[0].Id);
            Assert.AreEqual("3", imagesRankedByVotes[1].Id);
            Assert.AreEqual("1", imagesRankedByVotes[2].Id);
        }

        [Test]
        public void TestGetimagesRankedByVotesWithNullList()
        {
            Assert.DoesNotThrow(() => imageManagement.GetImagesRankedByVotes(null));
        }

        [Test]
        public void TestGetImagesToVoteWithEmptyList()
        {
            var imagesList = new List<Image>();
            var imagesToVote = imageManagement.GetImagesToVote(imagesList);
            Assert.IsEmpty(imagesToVote);
        }

        [Test]
        public void TestGetImagesToVoteWithNonEmptyList()
        {
            var imagesList = new List<Image> { new Image { Id = "1" }, new Image { Id = "2" }, new Image { Id = "3" } };
            var imagesToVote = imageManagement.GetImagesToVote(imagesList);
            Assert.AreEqual(2, imagesToVote.Count);
            Assert.AreNotEqual(imagesToVote[0].Id, imagesToVote[1].Id);
        }

        [Test]
        public void TestGetImagesToVoteWithNullList()
        {
            Assert.DoesNotThrow(() => imageManagement.GetImagesToVote(null));
        }

        [Test]
        public void TestGetTotalNumberOfVoteWithEmptyList()
        {
            var imagesList = new List<Image>();
            int totalNumberOfVotes = imageManagement.GetTotalNumberOfVotes(imagesList).GetValueOrDefault();
            Assert.AreEqual(0, totalNumberOfVotes);
        }

        [Test]
        public void TestGetTotalNumberOfVoteWithNonEmptyList()
        {
            var imagesList = new List<Image> { new Image { Id = "1" }, new Image { Id = "2" }, new Image { Id = "3" } };
            imageManagement.ApplyVote(imagesList, "2");
            imageManagement.ApplyVote(imagesList, "2");
            imageManagement.ApplyVote(imagesList, "2");
            imageManagement.ApplyVote(imagesList, "3");
            imageManagement.ApplyVote(imagesList, "3");
            imageManagement.ApplyVote(imagesList, "1");
            int totalNumberOfVotes = imageManagement.GetTotalNumberOfVotes(imagesList).GetValueOrDefault();
            Assert.AreEqual(6, totalNumberOfVotes);
        }

        [Test]
        public void TestGetTotalNumberOfVoteWithNullList()
        {
            Assert.DoesNotThrow(() => imageManagement.GetTotalNumberOfVotes(null));
        }
    }
}
