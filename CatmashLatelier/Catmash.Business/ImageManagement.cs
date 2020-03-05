using Catmash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catmash.Business
{
    public class ImageManagement
    {
        public void ApplyVote(IList<Image> imagesList, string id)
        {
            imagesList?.FirstOrDefault(i => i.Id.Equals(id))?.IncrementVotes();
        }

        public IList<Image> GetImagesRankedByVotes(IList<Image> imagesList)
        {
            return imagesList?.OrderByDescending(i => i.Votes).ToList();
        }

        public IList<Image> GetImagesToVote(IList<Image> imagesList)
        {
            IList<Image> imagesToVote = new List<Image>();
            if (imagesList?.Count > 0)
            {
                Random random = new Random();
                int num1 = random.Next(imagesList.Count);
                int num2 = num1;
                while (num1 == num2)
                {
                    num2 = random.Next(imagesList.Count);
                }
                imagesToVote.Add(imagesList[num1]);
                imagesToVote.Add(imagesList[num2]);
            }
            return imagesToVote;
        }

        public int? GetTotalNumberOfVotes(IList<Image> imagesList)
        {
            return imagesList?.Sum(i => i.Votes);
        }
    }
}
