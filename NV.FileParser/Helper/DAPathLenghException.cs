using System;
using System.Runtime.Serialization;

namespace NV.FileParser.Helper
{
    /// <summary>
    /// Path is to long for the fileSystem.
    /// </summary>
    public class DAPathLenghException : ArgumentOutOfRangeException
    {

        /// <summary>
        /// Create a new <see cref="DAPathLenghException"/>.
        /// </summary>
        public DAPathLenghException()
        {
        }



        /// <summary>
        /// Create a new <see cref="DAPathLenghException"/> with a parameter name.
        /// </summary>
        /// <param name="paramName">Parameter name</param>
        public DAPathLenghException(string paramName) : base(paramName)
        {

        }



        /// <summary>
        /// Create a new <see cref="DAPathLenghException"/> with a parameter name and a message.
        /// </summary>
        /// <param name="paramName">Parameter name</param>
        /// <param name="message">Message</param>
        public DAPathLenghException(string paramName, string message) : base(paramName, message)
        {

        }
    }
}
