using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using FileParser.Exceptions;
using FileParser.Properties;
using Observer.LogObserver;

namespace FileParser.Parser
{
    /// <summary>
    /// Save or load a binary file that contain an object.
    /// </summary>
    public class FPBinarySaveLoad : ISaveLoad
    {

        private readonly string m_defaultExtension = "bin";
        private string m_extension;
        private IExceptionObserver m_observer;



        #region Properties



        /// <summary>
        /// This return the extention of this <see cref="FPBinarySaveLoad"/>.
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
        /// This return the default extention of this <see cref="FPBinarySaveLoad"/>.
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
        /// Create a new instace of <see cref="FPBinarySaveLoad"/>.
        /// </summary>
        /// <param name="observer">This observer get notified if an exception get thrown.</param>
        public FPBinarySaveLoad(IExceptionObserver observer = null)
        {
            Observer = observer;
        }



        #region Public Methods



        /// <summary>
        /// Load the object from a file.
        /// </summary>
        /// <typeparam name="T">This object type get loaded.</typeparam>
        /// <param name="path">Load data from this file. Must contain directory + filename.</param>
        /// <returns>Returns an object of type T</returns>
        /// <exception cref="FPParserLoadException"></exception>
        public T Load<T>(string path)
        {
            FileStream stream = null;
            BinaryFormatter format;
            T readValue = default(T);

            try
            {
                stream = new FileStream(path, FileMode.Open);
                format = new BinaryFormatter();
                var read = format.Deserialize(stream);
                readValue = (T)Convert.ChangeType(read, typeof(T));
            }
            catch (Exception innerException)
            {
                FPParserExceptionHandler.HandleParserLoadException(innerException, nameof(FPBinarySaveLoad), path, Observer);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return readValue;
        }



        /// <summary>
        /// Save an object at <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">This object type get saved.</typeparam>
        /// <param name="value">This object get saved.</param>
        /// <param name="path">It get saved here. Must contain directory + filename.</param>
        /// <exception cref="FPParserSaveException"></exception>
        public void Save<T>(T value, string path)
        {
            FileStream stream = null;
            BinaryFormatter format;
            try
            {
                stream = new FileStream(path, FileMode.Create);
                format = new BinaryFormatter();
                format.Serialize(stream, value);
            }
            catch(Exception innerException)
            {
                FPParserExceptionHandler.HandleParserSaveException(innerException, nameof(FPBinarySaveLoad), path, value, typeof(T), Observer);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }



        /// <summary>
        /// Change the Extention of this <see cref="FPBinarySaveLoad"/>.
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
