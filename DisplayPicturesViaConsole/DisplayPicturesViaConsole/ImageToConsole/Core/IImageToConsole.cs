using System.Drawing;

namespace DisplayPicturesViaConsole.ImageToConsole.Core
{
    public interface IImageToConsole
    {
        void DisplayByBitmap(Bitmap bitmap);
    }
}