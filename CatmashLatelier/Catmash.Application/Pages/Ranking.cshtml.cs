using System.Collections.Generic;
using Catmash.Business;
using Catmash.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Catmash.Application.Pages
{
    public class RankingModel : PageModel
    {
        private readonly IImageDirectory _imageDirectory;
        public IList<Image> ImagesList { get; private set; }

        public RankingModel(IImageDirectory imageDirectory)
        {
            _imageDirectory = imageDirectory;
            ImageManagement imageManagement = new ImageManagement();
            ImagesList = imageManagement.GetImagesRankedByVotes(_imageDirectory.Images);
        }
    }
}