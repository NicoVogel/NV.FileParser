using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.LogObserver
{
    /// <summary>
    /// This is an interface for the exception notification.
    /// </summary>
    public interface IExceptionNotification
    {
        /// <summary>
        /// This exception get passed as information.
        /// </summary>
        Exception Exception { get; }
    }
}
