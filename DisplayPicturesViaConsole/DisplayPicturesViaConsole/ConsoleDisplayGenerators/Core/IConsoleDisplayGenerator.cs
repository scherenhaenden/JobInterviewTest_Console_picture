using System.Drawing;

namespace DisplayPicturesViaConsole.ConsoleDisplayGenerators.Core
{
    public interface IConsoleDisplayGenerator
    {
        void DoByBitMap(Bitmap image);

    }
}