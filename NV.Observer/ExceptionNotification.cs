using System;

namespace ExceptionObserver
{
    /// <summary>
    /// An usable exception notification that inherit from <see cref="IExceptionNotification"/>.
    /// </summary>
    public class ExceptionNotification : IExceptionNotification
    {
        private Exception m_exception;



        /// <summary>
        /// This exception get thrown.
        /// </summary>
        public Exception Exception
        {
            get
            {
                return m_exception;
            }
        }



        /// <summary>
        /// Create a new <see cref="ExceptionNotification"/> with the exception.
        /// </summary>
        /// <param name="ex">This is the exception for the notification</param>
        public ExceptionNotification(Exception ex)
        {
            m_exception = ex;
        }
    }
}
