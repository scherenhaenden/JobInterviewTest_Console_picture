using System;
using System.Drawing;
using System.Linq;

namespace DisplayPicturesViaConsole
{
    public static class ConsoleImageWriter
    {
        static readonly int[] availableColors =
        {
            0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF,
            0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF
        };

        public static void ConsoleWriteImageV3(Bitmap bitmapSource)
        {
            int sMax = 39;
            decimal percent = Math.Min(decimal.Divide(sMax, bitmapSource.Width),
                decimal.Divide(sMax, bitmapSource.Height));
            Size resSize = new Size((int) (bitmapSource.Width * percent), (int) (bitmapSource.Height * percent));
            Func<Color, int> ToConsoleColor = c =>
            {
                int index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0;
                index |= (c.R > 64) ? 4 : 0;
                index |= (c.G > 64) ? 2 : 0;
                index |= (c.B > 64) ? 1 : 0;
                return index;
            };
            Bitmap minBitmapSize = new Bitmap(bitmapSource, resSize.Width, resSize.Height);
            Bitmap maxBitmapSize = new Bitmap(bitmapSource, resSize.Width * 2, resSize.Height * 2);
            for (int height = 0; height < resSize.Height; height++)
            {
                for (int width = 0; width < resSize.Width; width++)
                {
                    Console.ForegroundColor = minBitmapSize.GenerateForegroundColor(width, height);
                    Console.Write("██");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("    ");

                for (int width = 0; width < resSize.Width; width++)
                {
                    Console.ForegroundColor = maxBitmapSize.GenerateForegroundColor(width, height);
                    Console.BackgroundColor = maxBitmapSize.GenerateBackgroundColor(width, height);
                    Console.Write("▀");

                    Console.ForegroundColor = maxBitmapSize.GenerateForegroundColor(width, height);
                    Console.BackgroundColor = maxBitmapSize.GenerateBackgroundColor(width, height);
                    Console.Write("▀");
                }

                Console.WriteLine();
            }
        }

        public static void ConsoleWriteImage(Bitmap source)
        {
            int sMax = 39;
            decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
            Size dSize = new Size((int) (source.Width * percent), (int) (source.Height * percent));
            Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
            for (int height = 0; height < dSize.Height; height++)
            {
                for (int width = 0; width < dSize.Width; width++)
                {
                    ConsoleWritePixel(bmpMax.GetPixel(width * 2, height));
                    ConsoleWritePixel(bmpMax.GetPixel(width * 2 + 1, height));
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public static void ConsoleWritePixel(Color cValue)
        {
            Color[] cTable = availableColors.Select(Color.FromArgb).ToArray();
            char[] rList = new char[] {(char) 9617, (char) 9618, (char) 9619, (char) 9608}; // 1/4, 2/4, 3/4, 4/4
            int[] bestHit = new int[] {0, 0, 4, int.MaxValue}; //ForeColor, BackColor, Symbol, Score

            for (int rChar = rList.Length; rChar > 0; rChar--)
            {
                for (int cFore = 0; cFore < cTable.Length; cFore++)
                {
                    for (int cBack = 0; cBack < cTable.Length; cBack++)
                    {
                        int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                        int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                        int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                        int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) +
                                     (cValue.B - B) * (cValue.B - B);
                        if (!(rChar > 1 && rChar < 4 && iScore > 50000)) // rule out too weird combinations
                        {
                            if (iScore < bestHit[3])
                            {
                                bestHit[3] = iScore; //Score
                                bestHit[0] = cFore; //ForeColor
                                bestHit[1] = cBack; //BackColor
                                bestHit[2] = rChar; //Symbol
                            }
                        }
                    }
                }
            }

            Console.ForegroundColor = (ConsoleColor) bestHit[0];
            Console.BackgroundColor = (ConsoleColor) bestHit[1];
            Console.Write(rList[bestHit[2] - 1]);
        }

        public static void ConsoleWriteImageV2(Bitmap src)
        {
            int min = 39;
            decimal pct = Math.Min(decimal.Divide(min, src.Width), decimal.Divide(min, src.Height));
            Size res = new Size((int) (src.Width * pct), (int) (src.Height * pct));
            Bitmap minBitmapSize = new Bitmap(src, res);
            for (int height = 0; height < res.Height; height++)
            {
                for (int width = 0; width < res.Width; width++)
                {
                    Console.ForegroundColor = minBitmapSize.GenerateForegroundColor(width, height);
                    Console.Write("██");
                }

                Console.WriteLine();
            }
        }
    }
}
