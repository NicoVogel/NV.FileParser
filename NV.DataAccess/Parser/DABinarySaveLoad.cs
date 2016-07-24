using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace NV.FileParser.Parser
{
    /// <summary>
    /// Save or load a binary file that contain an object.
    /// </summary>
    public class DABinarySaveLoad : ISaveLoad
    {

        private readonly string m_extention = "bin";



        #region Properties



        /// <summary>
        /// This return the Extention of this <see cref="DABinarySaveLoad"/>.
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
        /// Create a new instace of <see cref="DABinarySaveLoad"/>.
        /// </summary>
        public DABinarySaveLoad()
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
        public IOResult Save<T>(object value, string path)
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



        #endregion



    }
}
