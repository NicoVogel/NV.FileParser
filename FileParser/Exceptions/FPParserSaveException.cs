using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// Get thrown if an exception accour while saving a file.
    /// </summary>
    public class FPParserSaveException : FPException
    {
        /// <summary>
        /// create a new <see cref="FPParserSaveException"/> with a message and a inner exception.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="innerException">Contain the exception that was thrown while saving a file</param>
        public FPParserSaveException(string message, Exception innerException) : base(message, innerException) { }
    }
}
