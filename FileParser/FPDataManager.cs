using System;
using System.Linq;
using System.Collections.Generic;

using FileParser.Parser;
using FileParser.Properties;
using FileParser.Exceptions;
using Observer.LogObserver;

namespace FileParser
{
    /// <summary>
    /// This class manage the save and load commands.
    /// </summary>
    public class FPDataManager
    {

        private Dictionary<string, ISaveLoad> m_saveLoad;
        private IExceptionObserver m_observer;



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



        /// <summary>
        /// This observer get notifyed when an exception get thrown.
        /// </summary>
        public IExceptionObserver Observer
        {
            get { return m_observer; }
            set { m_observer = value; }
        }



        #endregion



        /// <summary>
        /// Create a new instance of <see cref="FPDataManager"/>.
        /// </summary>
        /// <param name="observer">This observer get notified if an exception get thrown.</param>
        public FPDataManager(IExceptionObserver observer = null)
        {
            Observer = observer;
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
        /// <exception cref="FPException"></exception>
        public void Save<T>(T value, string path, string type)
        {
            FPException ex = null;
            if (FPHelper.IsPathValid(path, out ex))
            {
                if (AllowedIO.Contains(type))
                {
                    if (SaveLoad[type] != null)
                        SaveLoad[type].Save(value, path);
                }
                else
                {
                    ex = new FPNotAllowedIOException(Resources.SaveNoAllowedIO + "\n" + Resources.exceptionMoreInformation);
                    ex.Data.Add("type", type);
                    ex.Data.Add("allowedTypes", AllowedIO);
                }
            }
            if (ex != null)
            {
                if (Observer != null)
                    Observer.Notify(new ExceptionNotification(ex));
                throw ex;
            }
        }



        /// <summary>
        /// Load an object form <paramref name="path"/> with the <paramref name="type"/>.
        /// </summary>
        /// <typeparam name="T">This object type get loaded</typeparam>
        /// <param name="path">Load the object from this path. String include file name!</param>
        /// <param name="type">Defines which load type be used to load the object.</param>
        /// <returns>Returns an object of type T</returns>
        /// <exception cref="FPException"></exception>
        public T Load<T>(string path, string type)
        {
            T readValue = default(T);
            FPException ex;

            if (FPHelper.IsPathValid(path, out ex))
            {
                if (AllowedIO.Contains(type))
                {
                    if (SaveLoad[type] != null)
                        readValue = SaveLoad[type].Load<T>(path);
                }
                else
                {
                    ex = new FPNotAllowedIOException(Resources.LoadNoAllowedIO + "\n" + Resources.exceptionMoreInformation);
                    ex.Data.Add("type", type);
                    ex.Data.Add("allowedTypes", AllowedIO);
                }
            }
            if (ex != null)
            {
                if (Observer != null)
                    Observer.Notify(new ExceptionNotification(ex));
                throw ex;
            }

            return readValue;
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

            io = new FPBinarySaveLoad(Observer);
            saveLoad.Add(io.Extension, io);

            io = new FPJsonSaveLoad(Observer);
            saveLoad.Add(io.Extension, io);

            io = new FPXmlSaveLoad(Observer);
            saveLoad.Add(io.Extension, io);

            io = new FPTextSaveLoad(Observer);
            saveLoad.Add(io.Extension, io);

            return saveLoad;
        }



        #endregion

    }
}
