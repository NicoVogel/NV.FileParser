using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// Get thrown if the contain non letter characters.
    /// </summary>
    public class FPExtensionNonLetterException : FPException
    {
        /// <summary>
        /// create a new <see cref="FPExtensionNonLetterException"/> with a message.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        public FPExtensionNonLetterException(string message) : base (message) { }
    }
}
