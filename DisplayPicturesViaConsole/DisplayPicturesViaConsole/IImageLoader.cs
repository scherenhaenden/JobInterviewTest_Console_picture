using System.IO;
using System.Threading.Tasks;

namespace DisplayPicturesViaConsole
{
    public interface IImageLoader
    {
        Task<Stream> Load(string path);
    }
}
