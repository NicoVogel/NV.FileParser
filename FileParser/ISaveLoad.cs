using System;
using FileParser.Exceptions;
using Observer.LogObserver;

namespace FileParser
{
    /// <summary>
    /// This interface is used to define a new parser to save and load an object.
    /// </summary>
    public interface ISaveLoad
    {

        #region Properties



        /// <summary>
        /// This return the extention of this <see cref="ISaveLoad"/>.
        /// </summary>
        string Extension { get; }


        /// <summary>
        /// This return the default extention of this <see cref="ISaveLoad"/>.
        /// </summary>
        string DefaultExtension { get; }



        /// <summary>
        /// This observer get notifyed if an exception get thrown.
        /// </summary>
        IExceptionObserver Observer { get; set; }



        #endregion



        /// <summary>
        /// Change the Extention of this <see cref="ISaveLoad"/>.
        /// </summary>
        /// <param name="extention">Only letters are allowed.</param>
        /// <exception cref="FPException"></exception>
        void SetExtention(string extention);



        /// <summary>
        /// Save a object at <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">This object type get saved.</typeparam>
        /// <param name="value">This object get saved.</param>
        /// <param name="path">It get saved here. Must contain directory + filename.</param>
        /// <exception cref="FPParserSaveException"></exception>
        void Save<T>(T value, string path);



        /// <summary>
        /// Load the object from a file.
        /// </summary>
        /// <typeparam name="T">This object type get loaded.</typeparam>
        /// <param name="path">Load data from this file. Must contain directory + filename.</param>
        /// <returns>Returns an object of type T</returns>
        /// <exception cref="FPParserLoadException"></exception>
        T Load<T>(string path);
    }
}

