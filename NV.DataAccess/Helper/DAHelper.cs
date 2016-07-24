using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace NV.FileParser.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class DAHelper
    {
        /// <summary>
        /// The max length of Windows 2000 is 254
        /// </summary>
        public const int MaxFileLenght_Windows2000 = 254;
        /// <summary>
        /// The max length of Windows Xp is 255
        /// </summary>
        public const int MaxFileLenght_WindowsXP = 255;
        /// <summary>
        /// The max length of Windows Vista is 260
        /// </summary>
        public const int MaxFileLenght_WindowsVista = 260;
        /// <summary>
        /// The max length of Windows 7 is 260
        /// </summary>
        public const int MaxFileLength_Windows7 = 260;



        /// <summary>
        /// Look for invalid file name characters in the parameter string.
        /// </summary>
        /// <param name="path">This string get tested.</param>
        /// <returns>true if everything is ok, false if not.</returns>
        public static bool IsPathValid(string path)
        {
            if (path.Length > 255)
                return false;
            string validCharacters = new String(System.IO.Path.GetInvalidFileNameChars());
            string pattern = "[" + Regex.Escape(validCharacters) + "]";
            var containsABadCharacter = new Regex(pattern);
            return containsABadCharacter.IsMatch(path);
        }

        /// <summary>
        /// Look for invalid file name characters in the parameter string.
        /// </summary>
        /// <param name="path">This string get tested.</param>
        /// <param name="ex"></param>
        /// <returns>true if everything is ok, false if not.</returns>
        public static bool IsPathValid(string path, out ArgumentException ex)
        {
            if (path.Length > 255)
            {
                ex = new DAPathLenghException(nameof(path), "The String is longer than 255 charecters.");
                return false;
            }
            else
                ex = null;


            Windows.MAX_Path

            string validCharacters = new String(System.IO.Path.GetInvalidFileNameChars());
            string pattern = "[" + Regex.Escape(validCharacters) + "]";
            var containsABadCharacter = new Regex(pattern);
            return containsABadCharacter.IsMatch(path);
        }
    }
}
