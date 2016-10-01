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
        private int m_eventID;

        /// <summary>
        /// Contains the event id of this exception
        /// </summary>
        public int EventID
        {
            get { return m_eventID; }
            set { m_eventID = value; }
        }

        /// <summary>
        /// Create a new <see cref="FPException"/> with a message.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        public FPException(string message) : base(message) { }

        /// <summary>
        /// Create a new <see cref="FPException"/> with a message and an event id.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="eventID">The id of this exception</param>
        public FPException(string message, int eventID) : base(message)
        {
            EventID = eventID;
        }

        /// <summary>
        /// Create a new <see cref="FPException"/> with a message and inner exception.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="innerException">This is the inner exception for this exception</param>
        public FPException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Create a new <see cref="FPException"/> with a message, inner exception and event id.
        /// </summary>
        /// <param name="message">Contain the exception message</param>
        /// <param name="innerException">This is the inner exception for this exception</param>
        /// <param name="eventID">The id of this exception</param>
        public FPException(string message, Exception innerException, int eventID) : base(message, innerException)
        {
            EventID = eventID;
        }
    }
}
