using System.IO;
using DisplayPicturesViaConsole.Repositories.Core;

namespace DisplayPicturesViaConsole.Repositories.Persistance
{
    public class FileGetterIO: IFileGetterIO
    {
        public Stream GetStreamByAddress(string addressOfFile)
        {
            var value = File.ReadAllBytes(addressOfFile);

            return new MemoryStream(value);
        }
    }
}