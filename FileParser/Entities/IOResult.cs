using System;

namespace FileParser.Entities
{
    /// <summary>
    /// This is the result of a save or load operation.
    /// </summary>
    public class IOResult
    {

        private Exception m_ex;
        private object m_value;



        #region Properties



        /// <summary>
        /// This is the Exception that get passed with this <see cref="IOResult"/>.
        /// </summary>
        public Exception IOException
        {
            get
            {
                return m_ex;
            }

            set
            {
                m_ex = value;
            }
        }



        /// <summary>
        /// This is the loaded object.
        /// </summary>
        public object Value
        {
            get
            {
                return m_value;
            }

            set
            {
                m_value = value;
            }
        }



        /// <summary>
        /// This is true if <see cref="IOException"/> is not null.
        /// </summary>
        public bool HasError
        {
            get
            {
                return IOException != null;
            }
        }



        #endregion



        #region Constructors



        /// <summary>
        /// Create a new empty instance of <see cref="IOResult"/>.
        /// </summary>
        public IOResult()
        {
            IOException = null;
            Value = null;
        }



        /// <summary>
        /// Create a new instance of <see cref="IOResult"/> with an exception.
        /// </summary>
        /// <param name="ex">The thrown exception</param>
        public IOResult(Exception ex) : this()
        {
            IOException = ex;
        }



        #endregion


    }
}
