using System.IO;

namespace DisplayPicturesViaConsole.Repositories.Core
{
    public interface IFileRepository
    {
        Stream GetStreamByAddress(string addressOfFile);
    }
}