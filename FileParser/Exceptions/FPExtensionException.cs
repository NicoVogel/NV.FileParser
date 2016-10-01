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
    public class FPExtensionException : FPException
    {
        /// <summary>
        /// create a new <see cref="FPExtensionException"/> with a message.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="eventID">The id of this exception</param>
        public FPExtensionException(string message, int eventID) : base(message, eventID) { }
    }
}
