using System;
using System.IO;
using System.Xml.Serialization;

namespace NV.FileParser.Parser
{
    /// <summary>
    /// Save or load a xml file that contain an object.
    /// </summary>
    public class DAXmlSaveLoad : ISaveLoad
    {

        private readonly string m_extention = "xml";



        #region Properties



        /// <summary>
        /// This return the Extention of this <see cref="DAXmlSaveLoad"/>.
        /// </summary>
        public string Extention
        {
            get
            {
                return m_extention;
            }
        }



        #endregion



        /// <summary>
        /// Create a new instace of <see cref="DAXmlSaveLoad"/>.
        /// </summary>
        public DAXmlSaveLoad()
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



        #endregion


    }
}
