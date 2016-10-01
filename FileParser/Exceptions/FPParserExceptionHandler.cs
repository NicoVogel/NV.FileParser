using System;

using FileParser.Properties;

namespace FileParser.Exceptions
{
    /// <summary>
    /// This class handles the Exceptions for the parser.
    /// </summary>
    public static class FPParserExceptionHandler
    {


        /// <summary>
        /// Create a new <see cref="FPParserLoadException"/>. 
        /// After that it thows the exception.
        /// </summary>
        /// <param name="innerException">This is the inner exception for the new exception.</param>
        /// <param name="className">Needed for the exception message.</param>
        /// <param name="path">This value gets saved into the exception data property. "path" is the key</param>
        /// <param name="eventID">The id of this exception</param>
        public static void HandleParserLoadException(Exception innerException, string className, string path, int eventID)
        {
            FPParserLoadException ex = new FPParserLoadException(
                String.Format(Resources.ErrorParser, Resources.methodLoadName, className) + "\n" + Resources.exceptionMoreInformation, 
                innerException,
                eventID);
            ex.Data.Add("path", path);
            throw ex;
        }



        /// <summary>
        /// Create a new <see cref="FPParserSaveException"/>. 
        /// After that it thows the exception.
        /// </summary>
        /// <param name="innerException">This is the inner exception for the new exception.</param>
        /// <param name="className">Needed for the exception message.</param>
        /// <param name="path">This value gets saved into the exception data property. "path" is the key</param>
        /// <param name="value">This value gets saved into the exception data property. "value" is the key</param>
        /// <param name="type">This value gets saved into the exception data property. "type" is the key</param>
        /// <param name="eventID">The id of this exception</param>
        public static void HandleParserSaveException(Exception innerException, string className, string path, object value, Type type, int eventID)
        {
            FPParserSaveException ex = new FPParserSaveException(
                String.Format(Resources.ErrorParser, Resources.methodReadName, className) + "\n" + Resources.exceptionMoreInformation, 
                innerException,
                eventID);
            ex.Data.Add("path", path);
            ex.Data.Add("type", type);
            ex.Data.Add("value", value);
            throw ex;
        }
    }
}
