using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// Get thrown if the file extension is to long or to short.
    /// </summary>
    public class FPExtensionLengthException : FPException
    {
        /// <summary>
        /// create a new <see cref="FPExtensionLengthException"/> with a message.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        public FPExtensionLengthException(string message) : base(message)
        {

        }
    }
}
