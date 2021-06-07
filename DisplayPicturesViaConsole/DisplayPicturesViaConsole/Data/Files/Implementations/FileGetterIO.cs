using System.IO;
using DisplayPicturesViaConsole.Data.Files.Core;

namespace DisplayPicturesViaConsole.Data.Files.Implementations
{
    public class FileGetterIO: IFileGetterIo
    {
        public Stream GetStreamByPath(string path)
        {
            var value = File.ReadAllBytes(path);

            return new MemoryStream(value);
        }
    }
}