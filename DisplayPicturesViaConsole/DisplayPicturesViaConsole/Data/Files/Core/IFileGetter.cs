using System.IO;

namespace DisplayPicturesViaConsole.Data.Files.Core
{
    public interface IFileGetter
    {
        Stream GetStreamByPath(string path);
    }
}