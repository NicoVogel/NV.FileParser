using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// Get thrown if the extension is null.
    /// </summary>
    public class FPExtenstionNullException : FPException
    {
        /// <summary>
        /// create a new <see cref="FPExtenstionNullException"/> with a message.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        public FPExtenstionNullException(string message) : base(message) { }
    }
}
