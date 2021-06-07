using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DisplayPicturesViaConsole.Repositories.Core;

namespace DisplayPicturesViaConsole.Repositories.Persistance
{
    public class FileGetterWeb: IFileGetterWeb
    {

        private async Task<Stream> GetStreamAsync(string addressOfFile)
        {
            using (HttpClient c = new HttpClient())
            {
                 var s = await c.GetByteArrayAsync(addressOfFile);

                 return new MemoryStream(s);
            }
        }

        public Stream GetStreamByAddress(string addressOfFile)
        {
            return GetStreamAsync(addressOfFile).Result;
        }
    }
}