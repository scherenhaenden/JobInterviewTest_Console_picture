using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DisplayPicturesViaConsole.Data.Files.Core;

namespace DisplayPicturesViaConsole.Data.Files.Implementations
{
    public class FileGetterWeb: IFileGetterWeb
    {
        public Stream GetStreamByPath(string path)
        {
            return GetStreamByPathAsync(path).Result;
        }
        
        private async Task<Stream> GetStreamByPathAsync(string addressOfFile)
        {
            using (var c = new HttpClient())
            {
                var s = await c.GetByteArrayAsync(addressOfFile);

                return new MemoryStream(s);
            }
        }
    }
}