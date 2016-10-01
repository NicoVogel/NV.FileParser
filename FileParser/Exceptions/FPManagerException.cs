using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    /// <summary>
    /// This exception get thrown for unexpected errors in the <see cref="FPDataManager"/>
    /// </summary>
    public class FPManagerException : FPException
    {
        /// <summary>
        /// Create a new <see cref="FPManagerException"/> with a message, inner exception and event id.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="innerException">This is the inner exception for this exception</param>
        /// <param name="eventID">The id of this exception</param>
        public FPManagerException(string message, Exception innerException, int eventID) : base(message, innerException, eventID)
        {
        }
    }
}
