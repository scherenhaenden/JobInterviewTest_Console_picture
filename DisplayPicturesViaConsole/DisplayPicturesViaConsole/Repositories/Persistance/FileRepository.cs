using System;
using System.IO;
using DisplayPicturesViaConsole.Repositories.Core;

namespace DisplayPicturesViaConsole.Repositories.Persistance
{
    public class FileRepository: IFileRepository
    {
        public Stream GetStreamByAddress(string addressOfFile)
        {
            if (IsStringValidUrl(addressOfFile))
            {
                return GetStream(new FileGetterWeb(), addressOfFile);
            }
            return GetStream(new FileGetterIO(), addressOfFile);
        }

        private bool IsStringValidUrl(string input)
        {
             return Uri.TryCreate(input, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
        }

        private Stream GetStream(IFileRepository repository, string addressOfFile)
        {
            return repository.GetStreamByAddress(addressOfFile);
        }
    }
}