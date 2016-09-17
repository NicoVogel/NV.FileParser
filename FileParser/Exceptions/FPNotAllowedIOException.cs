using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// Get thrown if for the extension exists no <see cref="ISaveLoad"/> object.
    /// </summary>
    public class FPNotAllowedIOException : FPException
    {
        /// <summary>
        /// Create a <see cref="FPNotAllowedIOException"/>
        /// </summary>
        /// <param name="message">This is the error message</param>
        public FPNotAllowedIOException(string message) : base(message) { }
    }
}
