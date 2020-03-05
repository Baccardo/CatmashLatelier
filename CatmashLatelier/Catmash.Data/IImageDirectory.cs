using System.Collections.Generic;

namespace Catmash.Data
{
    public interface IImageDirectory
    {
        IList<Image> Images { get; }
    }
}
