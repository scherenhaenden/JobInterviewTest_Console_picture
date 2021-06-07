using System;
using System.Drawing;
using DisplayPicturesViaConsole.ConsoleDisplayGenerators.Core;

namespace DisplayPicturesViaConsole.ConsoleDisplayGenerators.Implementation
{
    public class ConsoleDisplayGeneratorV2: IConsoleDisplayGenerator
    {
        public void ConsoleWriteImageV2(Bitmap src)
        {
            var min = 39;
            var pct = Math.Min(decimal.Divide(min, src.Width), decimal.Divide(min, src.Height));
            var res = new Size((int)(src.Width * pct), (int)(src.Height * pct));
            var bmpMin = new Bitmap(src, res);
            for (var i = 0; i < res.Height; i++)
            {
                for (var j = 0; j < res.Width; j++)
                {
                    Console.ForegroundColor = (ConsoleColor)ToConsoleColor(bmpMin.GetPixel(j, i));
                    Console.Write("██");
                }
                Console.WriteLine();
            }
        }
      
        public int ToConsoleColor(Color c)
        {
          var index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0;
          index |= (c.R > 64) ? 4 : 0;
          index |= (c.G > 64) ? 2 : 0;
          index |= (c.B > 64) ? 1 : 0;
          return index;
        }


        public void DoByBitMap(Bitmap image)
        {
          ConsoleWriteImageV2(image);
        }
    }
}