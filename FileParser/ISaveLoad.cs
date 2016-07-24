using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    /// <summary>
    /// This interface is used to define a new parser to save and load an object.
    /// </summary>
    public interface ISaveLoad
    {


        /// <summary>
        /// This return the Extention of this <see cref="ISaveLoad"/>.
        /// </summary>
        string Extention { get; }



        /// <summary>
        /// Save a object at <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">This object type get saved.</typeparam>
        /// <param name="value">This object get saved.</param>
        /// <param name="path">It get saved here. Must contain directory + filename.</param>
        /// <returns>Returns a <see cref="IOResult"/>.</returns>
        IOResult Save<T>(object value, string path);



        /// <summary>
        /// Load the object from a file.
        /// </summary>
        /// <typeparam name="T">This object type get loaded.</typeparam>
        /// <param name="path">Load data from this file. Must contain directory + filename.</param>
        /// <returns>Returns a <see cref="IOResult"/>.</returns>
        IOResult Load<T>(string path);
    }
}

