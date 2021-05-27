using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DisplayPicturesViaConsole
{
    public class NetworkImageLoader : IImageLoader
    {
        public async Task<Stream> Load(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new NullReferenceException($"Provided url ${url} is not set");

            try
            {

                using HttpClient httpClient = new();
                var imagePayload = await httpClient.GetByteArrayAsync(url);
                var stream = new MemoryStream(imagePayload);
                return stream;
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                    throw new Exception("Resource does not exist");
            }

            return null;
        }
    }
}
