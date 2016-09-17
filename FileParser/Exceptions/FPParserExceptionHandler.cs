using System;

using FileParser.Properties;
using Observer.LogObserver;

namespace FileParser.Exceptions
{
    /// <summary>
    /// This class handles the Exceptions for the parser.
    /// </summary>
    public static class FPParserExceptionHandler
    {


        /// <summary>
        /// Create a new <see cref="FPParserLoadException"/> and notify the <paramref name="observer"/>. 
        /// After that it thows the exception.
        /// </summary>
        /// <param name="innerException">This is the inner exception for the new exception.</param>
        /// <param name="className">Needed for the exception message.</param>
        /// <param name="path">This value gets saved into the exception data property. "path" is the key</param>
        /// <param name="observer">This observer get notified. Can be null.</param>
        public static void HandleParserLoadException(Exception innerException, string className, string path, IExceptionObserver observer)
        {
            FPParserLoadException ex = new FPParserLoadException(
                String.Format(Resources.parserException, Resources.methodLoadName, className) + "\n" + Resources.exceptionMoreInformation, 
                innerException);
            ex.Data.Add("path", path);
            if (observer != null)
                observer.Notify(new ExceptionNotification(ex));
            throw ex;
        }



        /// <summary>
        /// Create a new <see cref="FPParserSaveException"/> and notify the <paramref name="observer"/>. 
        /// After that it thows the exception.
        /// </summary>
        /// <param name="innerException">This is the inner exception for the new exception.</param>
        /// <param name="className">Needed for the exception message.</param>
        /// <param name="path">This value gets saved into the exception data property. "path" is the key</param>
        /// <param name="value">This value gets saved into the exception data property. "value" is the key</param>
        /// <param name="type">This value gets saved into the exception data property. "type" is the key</param>
        /// <param name="observer">This observer get notified. Can be null.</param>
        public static void HandleParserSaveException(Exception innerException, string className, string path, object value, Type type, IExceptionObserver observer)
        {
            FPParserSaveException ex = new FPParserSaveException(
                String.Format(Resources.parserException, Resources.methodReadName, className) + "\n" + Resources.exceptionMoreInformation, 
                innerException);
            ex.Data.Add("path", path);
            ex.Data.Add("type", type);
            ex.Data.Add("value", value);
            if (observer != null)
                observer.Notify(new ExceptionNotification(ex));
            throw ex;
        }
    }
}
