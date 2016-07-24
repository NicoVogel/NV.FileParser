using System;
using System.IO;
using Newtonsoft.Json;

namespace FileParser.Parser
{
    /// <summary>
    /// Save or load a json file that contain an object.
    /// </summary>
    public class FPJsonSaveLoad : ISaveLoad
    {

        private readonly string m_extention = "json";



        #region Properties

        

        /// <summary>
        /// This return the Extention of this <see cref="FPJsonSaveLoad"/>.
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
        /// Create a new instace of <see cref="FPJsonSaveLoad"/>.
        /// </summary>
        public FPJsonSaveLoad()
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

            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    res.Value = JsonConvert.DeserializeObject<T>(json);
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

            try
            {
                string json = JsonConvert.SerializeObject(value);
                File.WriteAllText(path, json);
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

