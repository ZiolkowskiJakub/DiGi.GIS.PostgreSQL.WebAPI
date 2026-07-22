using System.IO.Compression;

namespace DiGi.GIS.WebAPI.Constants
{
    /// <summary>
    /// Provides the compression settings applied to request payloads sent to the GIS PostgreSQL Web API.
    /// </summary>
    public static class Compression
    {
        /// <summary>
        /// The GZip compression level used for request payloads.
        /// <para><see cref="CompressionLevel.Fastest"/> rather than <see cref="CompressionLevel.Optimal"/>: on the bulk import path the client is CPU bound, and compressing a multi-megabyte JSON batch at <see cref="CompressionLevel.Optimal"/> costs several times more than it saves in transfer. Revisit if the link to the host becomes the bottleneck.</para>
        /// </summary>
        public static readonly CompressionLevel Level = CompressionLevel.Fastest;
    }
}
