using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileParser.Parser
{
    /// <summary>
    /// Save or load a binary file that contain an object.
    /// </summary>
    public class FPBinarySaveLoad : ISaveLoad
    {

        private readonly string m_defaultExtension = "bin";
        private string m_extension;



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



        #endregion



        /// <summary>
        /// Create a new instace of <see cref="FPBinarySaveLoad"/>.
        /// </summary>
        public FPBinarySaveLoad()
        {

        }



        #region Public Methods



        /// <summary>
        /// Load the object from a file.
        /// </summary>
        /// <typeparam name="T">This object type get loaded.</typeparam>
        /// <param name="path">Load data from this file. Must contain directory + filename.</param>
        /// <returns>Returns a <see cref="IOResult"/>.</returns>
        public IOResult Load<T>(string path)
        {
            IOResult res = new IOResult();
            FileStream stream = null;
            BinaryFormatter format;

            try
            {
                stream = new FileStream(path, FileMode.Open);
                format = new BinaryFormatter();
                res.Value = format.Deserialize(stream);

            }
            catch (Exception ex)
            {
                res.IOException = ex;
                res.Value = null;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return res;
        }



        /// <summary>
        /// Save an object at <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">This object type get saved.</typeparam>
        /// <param name="value">This object get saved.</param>
        /// <param name="path">It get saved here. Must contain directory + filename.</param>
        /// <returns>Returns a <see cref="IOResult"/>.</returns>
        public IOResult Save<T>(T value, string path)
        {
            IOResult res = new IOResult();
            FileStream stream = null;
            BinaryFormatter format;
            try
            {
                stream = new FileStream(path, FileMode.Create);
                format = new BinaryFormatter();
                format.Serialize(stream, value);
            }
            catch (Exception ex)
            {
                res.IOException = ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }



            return res;
        }



        /// <summary>
        /// Change the Extention of this <see cref="FPBinarySaveLoad"/>.
        /// </summary>
        /// <param name="extension">Only letters are allowed.</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetExtention(string extension)
        {
            ArgumentException ex;
            if (FPHelper.IsExtentionValid(extension, out ex))
            {
                m_extension = extension;
            }
            else
            {
                throw ex;
            }
        }



        #endregion



    }
}
