using System;
using System.Runtime.Serialization;

namespace FileParser.Helper
{
    /// <summary>
    /// Path is to long for the fileSystem.
    /// </summary>
    public class FPPathLenghException : ArgumentOutOfRangeException
    {

        /// <summary>
        /// Create a new <see cref="FPPathLenghException"/>.
        /// </summary>
        public FPPathLenghException()
        {
        }



        /// <summary>
        /// Create a new <see cref="FPPathLenghException"/> with a parameter name.
        /// </summary>
        /// <param name="paramName">Parameter name</param>
        public FPPathLenghException(string paramName) : base(paramName)
        {

        }



        /// <summary>
        /// Create a new <see cref="FPPathLenghException"/> with a parameter name and a message.
        /// </summary>
        /// <param name="paramName">Parameter name</param>
        /// <param name="message">Message</param>
        public FPPathLenghException(string paramName, string message) : base(paramName, message)
        {

        }
    }
}
