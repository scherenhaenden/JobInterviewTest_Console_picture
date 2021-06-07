using System;
using System.IO;
using DisplayPicturesViaConsole.Data.Files.Core;

namespace DisplayPicturesViaConsole.Data.Files.Implementations
{
    public class FileGetter: IFileGetter
    {
        public Stream GetStreamByPath(string path)
        {
            if (IsPathUrl(path))
            {
                return GetStreamByPath(new FileGetterWeb(), path);

            }
            return GetStreamByPath(new FileGetterIO(), path);
        }

        private Stream GetStreamByPath(IFileGetter fileGetter, string path)
        {
            return fileGetter.GetStreamByPath(path);
        }


        private bool IsPathUrl(string path)
        {
            return Uri.TryCreate(path, UriKind.Absolute, out var uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
        }
    }
}