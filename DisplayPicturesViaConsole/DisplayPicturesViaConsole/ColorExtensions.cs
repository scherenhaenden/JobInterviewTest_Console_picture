using System;
using System.Drawing;

namespace DisplayPicturesViaConsole
{
    public static class ColorExtensions
    {
        private static ConsoleColor ToConsoleColor(this Color c)
        {
            int index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0;
            index |= (c.R > 64) ? 4 : 0;
            index |= (c.G > 64) ? 2 : 0;
            index |= (c.B > 64) ? 1 : 0;
            return (ConsoleColor) index;
        }

        public static ConsoleColor GenerateForegroundColor(this Bitmap bitmap, int firstPixel, int secondPixel) =>
            bitmap.GetPixel(firstPixel * 2 + 1, secondPixel * 2).ToConsoleColor();

        public static ConsoleColor GenerateBackgroundColor(this Bitmap bitmap, int firstPixel, int secondPixel) =>
            bitmap.GetPixel(firstPixel * 2 + 1, secondPixel * 2 + 1).ToConsoleColor();

        //bmpMax.GetPixel(j * 2 + 1, i * 2 + 1)
    }
}
