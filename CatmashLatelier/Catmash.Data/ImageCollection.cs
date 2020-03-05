using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Catmash.Data
{
    [DataContract]
    public class ImageCollection
    {
        [DataMember(Name = "images")]
        public IList<Image> Images { get; set; }
    }
}
