using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        public static async Task<HttpContent?> HttpContent(this string json, CancellationToken cancellationToken)
        {
            if(string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            // Convert JSON string to byte array (UTF8)
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            return await HttpContent(jsonBytes, cancellationToken);
        }

        public static async Task<HttpContent?> HttpContent(this byte[] bytes, CancellationToken cancellationToken)
        {
            if (bytes is null)
            {
                return null;
            }

            HttpContent result;

            //Decide if we want to use Gzip (optional: you could add a threshold here, e.g., if jsonBytes.Length > 1024)
            MemoryStream memoryStream = new();
            
            using (GZipStream gzipStream = new(memoryStream, CompressionLevel.Optimal, leaveOpen: true))
            {
                await gzipStream.WriteAsync(bytes, 0, bytes.Length, cancellationToken).ConfigureAwait(false);
            }

            //Move pointer to the beginning of the compressed stream
            memoryStream.Position = 0;

            // Create ByteArrayContent from compressed stream
            result = new StreamContent(memoryStream);

            //CRITICAL HEADERS: Tell the API this is JSON and it is GZIPPED
            result.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
                CharSet = Encoding.UTF8.WebName
            };
            result.Headers.ContentEncoding.Add("gzip");

            return result;
        }
    }
}
