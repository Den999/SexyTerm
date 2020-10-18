using System.Text;

namespace MyConsole
{
    /// <summary>
    /// Contains string extensions methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// List of supported encodings (list of tuples)
        /// </summary>
        public static (string name, Encoding encoding)[] SupportedEncodings =
        {
            ("d", Encoding.Default),
            ("utf8", Encoding.UTF8),
            ("unicode", Encoding.Unicode),
            ("ascii", Encoding.ASCII),
        };

        /// <summary>
        /// Tries to convert string to encoding. If convertion failed returns default encoding.  
        /// </summary>
        /// <param name="line">string to parse.</param>
        /// <returns>parsed encoding.</returns>
        public static Encoding ParseEncoding(this string line)
        {
            // Find the encoding user specified by name
            foreach (var supportedEncoding in SupportedEncodings)
            {
                if (supportedEncoding.name == line)
                    return supportedEncoding.encoding;
            }

            return Encoding.Default;
        }
    }
}