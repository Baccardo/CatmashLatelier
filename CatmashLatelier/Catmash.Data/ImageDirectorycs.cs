using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Catmash.Data
{
    public class ImageDirectory : IImageDirectory
    {
        public IList<Image> Images { get; }

        public ImageDirectory(IConfiguration config)
        {
            var task = Task.Run(async () => await GetImagesAsync(config["CatsUrl"]));
            Images = task.Result;
        }

        private async Task<IList<Image>> GetImagesAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(ImageCollection));
                var stream = client.GetStreamAsync(url);
                return (jsonSerializer.ReadObject(await stream) as ImageCollection)?.Images;
            }
        }
    }
}
