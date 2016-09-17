using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// Get thrown if an exception accour while loading a file.
    /// </summary>
    public class FPParserLoadException : FPException
    {
        /// <summary>
        /// create a new <see cref="FPParserLoadException"/> with a message and a inner exceptin.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="innerException">Contain the exception that was thrown while loading a file</param>
        public FPParserLoadException(string message, Exception innerException) : base(message, innerException) { }
    }
}
