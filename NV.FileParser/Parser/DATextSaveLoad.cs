using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV.FileParser.Parser
{
    /// <summary>
    /// Save or load a text file that contain an string.
    /// </summary>
    public class DATextSaveLoad : ISaveLoad
    {

        private readonly string m_extention = "txt";



        #region Properties



        /// <summary>
        /// This return the Extention of this <see cref="DATextSaveLoad"/>.
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
        /// Create a new instace of <see cref="DATextSaveLoad"/>.
        /// </summary>
        public DATextSaveLoad()
        {

        }



        #region Public Methods



        /// <summary>
        /// Save a object at <paramref name="path"/>.
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
                File.WriteAllText(path, value.ToString());
            }
            catch (Exception ex)
            {
                res.IOException = ex;
            }

            return res;
        }



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
                res.Value = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                res.IOException = ex;
            }

            return res;
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
            return !Save<String>(text, path).HasError;
        }
        


        #endregion



    }
}
