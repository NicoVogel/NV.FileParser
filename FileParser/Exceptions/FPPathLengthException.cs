﻿using System;
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
        public FPPathLengthException(string message) : base(message) { }
    }
}
