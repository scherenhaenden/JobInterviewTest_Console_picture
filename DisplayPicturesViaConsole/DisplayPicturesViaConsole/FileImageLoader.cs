using System;
using System.IO;
using System.Threading.Tasks;

namespace DisplayPicturesViaConsole
{
    public class FileImageLoader : IImageLoader
    {
        public async Task<Stream> Load(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new NullReferenceException($"Provided path ${path} is not set");

                var finalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

                var fileExists = File.Exists(finalPath);
                if (!fileExists)
                {
                    return null;
                }

                var bytes = await File.ReadAllBytesAsync(finalPath);
                var stream = new MemoryStream(bytes);
                return stream;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
