using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DisplayPicturesViaConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fileImageLoader = new FileImageLoader();
            var imageFetcherService = new ImageFetcherService(fileImageLoader);
            var fromFileBitmap = await imageFetcherService.Fetch("Data/36c3-open-source-hardware-dangers-featured.jpg");
            ConsoleImageWriter.ConsoleWriteImage(fromFileBitmap);
            ConsoleImageWriter.ConsoleWriteImageV2(fromFileBitmap);
            ConsoleImageWriter.ConsoleWriteImageV3(fromFileBitmap);
            ConsoleImageWriter.ConsoleWriteImageV3(fromFileBitmap);

            var networkImageLoader = new NetworkImageLoader();
            var networkImageFetcher = new ImageFetcherService(networkImageLoader);
            var url = "https://rockatuestilo.com/uploads/20200807_munich_backstage_kalapi/AOL_3970.jpg";
            var fromNetworkBitmap = await networkImageFetcher.Fetch(url);
            ConsoleImageWriter.ConsoleWriteImage(fromNetworkBitmap);
            ConsoleImageWriter.ConsoleWriteImageV2(fromNetworkBitmap);
            ConsoleImageWriter.ConsoleWriteImageV3(fromNetworkBitmap);
        }
    }
}