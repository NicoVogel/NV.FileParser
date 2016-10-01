using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// Get thrown if the file path is to long.
    /// </summary>
    public class FPPathLengthException : FPException
    {
        /// <summary>
        /// create a new <see cref="FPPathLengthException"/> with a message.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="eventID">The id of this exception</param>
        public FPPathLengthException(string message, int eventID) : base(message, eventID) { }
    }
}
