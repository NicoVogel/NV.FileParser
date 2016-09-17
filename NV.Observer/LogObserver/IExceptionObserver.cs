using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.LogObserver
{
    /// <summary>
    /// This is the exception observer that recieves notifications of exceptions.
    /// </summary>
    public interface IExceptionObserver
    {
        /// <summary>
        /// Notify the observer that an exception was thrown and pass the exception.
        /// </summary>
        /// <param name="notification">This contain the exceptino that get thrown.</param>
        void Notify(IExceptionNotification notification);
    }
}
