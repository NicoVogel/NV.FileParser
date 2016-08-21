using System;
using System.IO;

namespace FileParser.Parser
{
    /// <summary>
    /// Save or load a text file that contain an string.
    /// </summary>
    public class FPTextSaveLoad : ISaveLoad
    {

        private readonly string m_defaultExtension = "txt";
        private string m_extension = "txt";



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



        #endregion



        /// <summary>
        /// Create a new instace of <see cref="FPTextSaveLoad"/>.
        /// </summary>
        public FPTextSaveLoad()
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
        public IOResult Save<T>(T value, string path)
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



        /// <summary>
        /// Change the Extention of this <see cref="FPTextSaveLoad"/>.
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
