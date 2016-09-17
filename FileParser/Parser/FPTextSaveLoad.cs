using System;
using System.IO;

using FileParser.Exceptions;
using ExceptionObserver;

namespace FileParser.Parser
{
    /// <summary>
    /// Save or load a text file that contain an string.
    /// </summary>
    public class FPTextSaveLoad : ISaveLoad
    {

        private readonly string m_defaultExtension = "txt";
        private string m_extension;
        private IExceptionObserver m_observer;



        #region Properties



        /// <summary>
        /// This return the Extention of this <see cref="FPTextSaveLoad"/>.
        /// </summary>
        public string Extension
        {
            get
            {
                if (String.IsNullOrEmpty(m_extension))
                    m_extension = m_defaultExtension;
                return m_extension;
            }
        }



        /// <summary>
        /// This return the default extention of this <see cref="FPTextSaveLoad"/>.
        /// </summary>
        public string DefaultExtension
        {
            get
            {
                return m_defaultExtension;
            }
        }


        /// <summary>
        /// This observer get notifyed if an exception get thrown.
        /// </summary>
        public IExceptionObserver Observer
        {
            get
            {
                return m_observer;
            }

            set
            {
                m_observer = value;
            }
        }



        #endregion



        /// <summary>
        /// Create a new instace of <see cref="FPTextSaveLoad"/>.
        /// </summary>
        /// <param name="observer">This observer get notified if an exception get thrown.</param>
        public FPTextSaveLoad(IExceptionObserver observer = null)
        {
            Observer = observer;
        }



        #region Public Methods



        /// <summary>
        /// Save a object at <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">This object type get saved.</typeparam>
        /// <param name="value">This object get saved.</param>
        /// <param name="path">It get saved here. Must contain directory + filename.</param>
        /// <exception cref="FPParserSaveException"></exception>
        public void Save<T>(T value, string path)
        {
            try
            {
                File.WriteAllText(path, value.ToString());
            }
            catch (Exception innerException)
            {
                FPParserExceptionHandler.HandleParserSaveException(innerException, nameof(FPBinarySaveLoad), path, value, typeof(T), Observer);
            }
        }



        /// <summary>
        /// Load the object from a file.
        /// </summary>
        /// <typeparam name="T">This object type get loaded.</typeparam>
        /// <param name="path">Load data from this file. Must contain directory + filename.</param>
        /// <returns>Returns an object of type T</returns>
        /// <exception cref="FPParserLoadException"></exception>
        public T Load<T>(string path)
        {
            T readValue = default(T);
            try
            {
                var read = File.ReadAllText(path);
                readValue = (T)Convert.ChangeType(read, typeof(T));
            }
            catch (Exception innerException)
            {
                FPParserExceptionHandler.HandleParserLoadException(innerException, nameof(FPBinarySaveLoad), path, Observer);
            }
            return readValue;
        }



        /// <summary>
        /// Load all text rows from a file.
        /// </summary>
        /// <param name="path">Load data from this file. Must contain directory + filename.</param>
        /// <param name="rows">The loaded rows or null if it didnt work.</param>
        /// <returns>True if it worked, false if not.</returns>
        public bool LoadRows(string path, out string[] rows)
        {
            try
            {
                rows = File.ReadAllLines(path);
                return true;
            }
            catch (Exception)
            {
                rows = null;
                return false;
            }
        }



        /// <summary>
        /// Save a string at <paramref name="path"/>.
        /// </summary>
        /// <param name="text">This text get saved.</param>
        /// <param name="path">It get saved here. Must contain directory + filename.</param>
        /// <returns>True if it worked, false if not.</returns>
        public bool Save(string text, string path)
        {
            try
            {
                Save<String>(text, path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Change the Extention of this <see cref="FPTextSaveLoad"/>.
        /// </summary>
        /// <param name="extension">Only letters are allowed.</param>
        /// <exception cref="FPException"></exception>
        public void SetExtention(string extension)
        {
            m_extension = FPHelper.SetExtenstionManager(extension, Observer);
        }



        #endregion



    }
}
