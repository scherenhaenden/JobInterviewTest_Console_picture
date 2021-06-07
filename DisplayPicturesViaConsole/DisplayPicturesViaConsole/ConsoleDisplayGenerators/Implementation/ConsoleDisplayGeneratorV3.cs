using System;
using System.Drawing;
using DisplayPicturesViaConsole.ConsoleDisplayGenerators.Core;

namespace DisplayPicturesViaConsole.ConsoleDisplayGenerators.Implementation
{
    public class ConsoleDisplayGeneratorV3: IConsoleDisplayGenerator
    {
        public void DoByBitMap(Bitmap image)
        {
            ConsoleWriteImageV3(image);
        }
        public void ConsoleWriteImageV3(Bitmap bmpSrc)
        {
            var sMax = 39;
            var percent = Math.Min(decimal.Divide(sMax, bmpSrc.Width), decimal.Divide(sMax, bmpSrc.Height));
            var resSize = new Size((int)(bmpSrc.Width * percent), (int)(bmpSrc.Height * percent));
            Func<Color, int> ToConsoleColor = c =>
            {
                var index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0;
                index |= (c.R > 64) ? 4 : 0;
                index |= (c.G > 64) ? 2 : 0;
                index |= (c.B > 64) ? 1 : 0;
                return index;
            };
            var bmpMin = new Bitmap(bmpSrc, resSize.Width, resSize.Height);
            var bmpMax = new Bitmap(bmpSrc, resSize.Width * 2, resSize.Height * 2);
            for (var i = 0; i < resSize.Height; i++)
            {
                for (var j = 0; j < resSize.Width; j++)
                {
                    Console.ForegroundColor = (ConsoleColor)ToConsoleColor(bmpMin.GetPixel(j, i));
                    Console.Write("██");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("    ");

                for (var j = 0; j < resSize.Width; j++)
                {
                    Console.ForegroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2, i * 2));
                    Console.BackgroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2, i * 2 + 1));
                    Console.Write("▀");

                    Console.ForegroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2 + 1, i * 2));
                    Console.BackgroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2 + 1, i * 2 + 1));
                    Console.Write("▀");
                }
                Console.WriteLine();
            }
        }
    }
}