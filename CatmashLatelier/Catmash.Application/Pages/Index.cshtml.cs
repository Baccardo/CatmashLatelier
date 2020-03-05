using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Catmash.Data;
using Catmash.Business;

namespace Catmash.Application.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IImageDirectory _imageDirectory;
        public IList<Image> ImagesList;
        public int TotalNumberOfVotes;

        public IndexModel(IImageDirectory imageDirectory)
        {
            _imageDirectory = imageDirectory;
            ImageManagement imageManagement = new ImageManagement();
            ImagesList = imageManagement.GetImagesToVote(_imageDirectory?.Images);
            TotalNumberOfVotes = imageManagement.GetTotalNumberOfVotes(_imageDirectory?.Images).GetValueOrDefault();
        }

        public void OnPostVote(string id)
        {
            ImageManagement imageManagement = new ImageManagement();
            imageManagement.ApplyVote(_imageDirectory?.Images, id);
            TotalNumberOfVotes = imageManagement.GetTotalNumberOfVotes(_imageDirectory?.Images).GetValueOrDefault();
        }
    }
}
