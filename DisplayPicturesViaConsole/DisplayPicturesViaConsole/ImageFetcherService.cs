using System.Drawing;
using System.Threading.Tasks;

namespace DisplayPicturesViaConsole
{
    public class ImageFetcherService
    {
        private readonly IImageLoader _imageLoader;

        public ImageFetcherService(IImageLoader imageLoader)
        {
            _imageLoader = imageLoader;
        }

        public async Task<Bitmap> Fetch(string resource)
        {
            var bitmap = await _imageLoader.Load(resource);
            var finalBitmap = Image.FromStream(bitmap) as Bitmap;
            return finalBitmap;
        }
    }
}
