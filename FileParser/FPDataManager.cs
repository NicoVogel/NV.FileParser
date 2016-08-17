﻿using System;
using System.Linq;
using System.Collections.Generic;

using FileParser.Entities;
using FileParser.Parser;
using FileParser.Properties;
using FileParser.Helper;

namespace FileParser
{
    /// <summary>
    /// This class manage the save and load commands.
    /// </summary>
    public class FPDataManager
    {

        private Dictionary<string, ISaveLoad> m_saveLoad;



        #region Properties



        /// <summary>
        /// Contain the allowed IO extentions.
        /// </summary>
        public List<string> AllowedIO
        {
            get
            {
                return SaveLoad.Keys.ToList();
            }
        }



        /// <summary>
        /// Contain the <see cref="ISaveLoad"/> objects.
        /// </summary>
        public Dictionary<string, ISaveLoad> SaveLoad
        {
            get
            {
                return m_saveLoad;
            }

            set
            {
                m_saveLoad = value;
            }
        }



        /// <summary>
        /// Contain the default save load objects.
        /// </summary>
        public Dictionary<string, ISaveLoad> DefaultSaveLoad
        {
            get
            {
                return defaultSaveLoadObjects();
            }
        }



        #endregion



        /// <summary>
        /// Create a new instance of <see cref="FPDataManager"/>.
        /// </summary>
        public FPDataManager()
        {
            SaveLoad = defaultSaveLoadObjects();
        }



        #region Public Methods



        /// <summary>
        /// Save the <paramref name="value"/> at <paramref name="path"/> with the <paramref name="type"/>.
        /// </summary>
        /// <typeparam name="T">This object type get saved.</typeparam>
        /// <param name="value">This object get saved.</param>
        /// <param name="path">Save the object at this path. String include file name!</param>
        /// <param name="type">Defines which save type be used to save the <paramref name="value"/>.</param>
        /// <returns>This result object <see cref="IOResult"/> contain exceptions.</returns>
        public IOResult Save<T>(object value, string path, string type)
        {
            IOResult result = null;
            try
            {
                ArgumentException ex;
                if (FPHelper.IsPathValid(path, out ex))
                {
                    if (AllowedIO.Contains(type))
                    {
                        if (SaveLoad[type] != null)
                            result = SaveLoad[type].Save<T>(value, path);
                    }
                    else
                    {
                        throw new ArgumentException(Resources.SaveNoAllowedIO);
                    }
                }
                else
                    result.IOException = ex;
            }
            catch (Exception ex)
            {
                result = new IOResult(ex);
            }
            return result;
        }



        /// <summary>
        /// Load an object form <paramref name="path"/> with the <paramref name="type"/>.
        /// </summary>
        /// <typeparam name="T">This object type get loaded</typeparam>
        /// <param name="path">Load the object from this path. String include file name!</param>
        /// <param name="type">Defines which load type be used to load the object.</param>
        /// <returns>This result object <see cref="IOResult"/> contain exceptions and the loaded object.</returns>
        public IOResult Load<T>(string path, string type)
        {
            IOResult result = null;
            try
            {
                if (AllowedIO.Contains(type))
                {
                    if (SaveLoad[type] != null)
                        result = SaveLoad[type].Load<T>(path);
                }
                else
                {
                    throw new ArgumentException(Resources.LoadNoAllowedIO);
                }
            }
            catch (Exception ex)
            {
                result = new IOResult(ex);
            }
            return result;
        }




        #endregion
        
        #region Private Methods



        /// <summary>
        /// This method create the default set of <see cref="ISaveLoad"/> objects.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, ISaveLoad> defaultSaveLoadObjects()
        {
            var saveLoad = new Dictionary<string, ISaveLoad>();
            ISaveLoad io = null;

            io = new FPBinarySaveLoad();
            saveLoad.Add(io.Extension, io);

            io = new FPJsonSaveLoad();
            saveLoad.Add(io.Extension, io);

            io = new FPXmlSaveLoad();
            saveLoad.Add(io.Extension, io);

            io = new FPTextSaveLoad();
            saveLoad.Add(io.Extension, io);

            return saveLoad;
        }



        #endregion

    }
}
