using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using DisplayPicturesViaConsole.ConsoleDisplayGenerators.Core;
using DisplayPicturesViaConsole.ConsoleDisplayGenerators.Implementation;
using DisplayPicturesViaConsole.Data.Files.Core;
using DisplayPicturesViaConsole.Data.Files.Implementations;

namespace DisplayPicturesViaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ioIamge = "https://rockatuestilo.com/uploads/20200807_munich_backstage_kalapi/AOL_3970.jpg";
    
            IFileGetter fileGetter = new FileGetter(); 
            var imagePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Data/36c3-open-source-hardware-dangers-featured.jpg";
            var streamImage = fileGetter.GetStreamByPath(ioIamge);

            var image = new Bitmap(streamImage);

            IConsoleDisplayGenerator IConsoleDisplayGenerator = new ConsoleDisplayGeneratorV3();
            
            IConsoleDisplayGenerator.DoByBitMap(image);

            Console.WriteLine("Hello World!");
        }
    }
}