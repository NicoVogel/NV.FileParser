using System;
using System.IO;
using System.Xml.Serialization;

using FileParser.Entities;
using FileParser.Helper;

namespace FileParser.Parser
{
    /// <summary>
    /// Save or load a xml file that contain an object.
    /// </summary>
    public class FPXmlSaveLoad : ISaveLoad
    {

        private readonly string m_defaultExtension = "xml";
        private string m_extension = "xml";



        #region Properties



        /// <summary>
        /// This return the Extention of this <see cref="FPXmlSaveLoad"/>.
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
        /// This return the default extention of this <see cref="FPXmlSaveLoad"/>.
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
        /// Create a new instace of <see cref="FPXmlSaveLoad"/>.
        /// </summary>
        public FPXmlSaveLoad()
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
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    res.Value = serializer.Deserialize(reader);
                    
                }
            }
            catch (Exception ex)
            {
                res.IOException = ex;
                res.Value = null;
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
        public IOResult Save<T>(object value, string path)
        {
            IOResult res = new IOResult();
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, value);
                }
            }
            catch (Exception ex)
            {
                res.IOException = ex;
            }

            return res;
        }



        /// <summary>
        /// Change the Extention of this <see cref="FPXmlSaveLoad"/>.
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
