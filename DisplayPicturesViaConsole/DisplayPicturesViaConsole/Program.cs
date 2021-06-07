using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DisplayPicturesViaConsole.ImageToConsole.Core;
using DisplayPicturesViaConsole.ImageToConsole.Persistance;
using DisplayPicturesViaConsole.Repositories.Core;
using DisplayPicturesViaConsole.Repositories.Persistance;

namespace DisplayPicturesViaConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            IFileRepository fileRepository = new FileRepository();
            var imagePath = "https://rockatuestilo.com/uploads/20200807_munich_backstage_kalapi/AOL_3970.jpg";
            
            //var imagePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Data/36c3-open-source-hardware-dangers-featured.jpg";
            
            var stream = fileRepository.GetStreamByAddress(imagePath);

            IImageToConsole imageToConsole = new ImateToConsoleV3();
            var hh = new Bitmap(stream);
            imageToConsole.DisplayByBitmap(new Bitmap(stream));

            Console.WriteLine("Hello World!");
        }


      
    }
    
    
}