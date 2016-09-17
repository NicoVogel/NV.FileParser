using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// This is the main exception class for this DLL. All exceptions from "FileParser.Exceptions" inherit from this exception.
    /// </summary>
    public abstract class FPException : Exception
    {
        /// <summary>
        /// Create a new <see cref="FPException"/> with a message.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        public FPException(string message) : base(message) { }
        /// <summary>
        /// Create a new <see cref="FPException"/> with a message and a inner exception.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="innerException">This is the inner exception for this exception</param>
        public FPException(string message, Exception innerException) : base(message, innerException) { }
    }
}
