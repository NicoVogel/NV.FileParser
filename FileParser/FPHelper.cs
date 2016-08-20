using System;
using System.Text.RegularExpressions;

using FileParser.Properties;

namespace FileParser
{
    /// <summary>
    /// 
    /// </summary>
    public static class FPHelper
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
        /// This regex contain all legal caracters.
        /// </summary>
        public static readonly Regex LegalCharacter = new Regex(@"[\w\$#&\+@!\(\)\{\}\.'`~, ]*");



        /// <summary>
        /// Look for invalid file name characters and check the length with 255.
        /// </summary>
        /// <param name="path">This string get tested.</param>
        /// <returns>true if everything is ok, false if not.</returns>
        public static bool IsPathValid(string path)
        {
            return path.Length <= 255 && LegalCharacter.IsMatch(path);
        }



        /// <summary>
        /// Look for invalid file name characters in the parameter string.
        /// </summary>
        /// <param name="path">This string get tested.</param>
        /// <param name="ex"></param>
        /// <returns>true if everything is ok, false if not.</returns>
        public static bool IsPathValid(string path, out ArgumentException ex)
        {
            int length = 255;
            if (path.Length > length)
            {
                ex = new ArgumentException(nameof(path), String.Format(Resources.helperPathLenght, length.ToString()));
                return false;
            }
            else
                ex = null;
            return LegalCharacter.IsMatch(path);
        }



        /// <summary>
        /// Look if extension is valid.
        /// </summary>
        /// <param name="extension">Not null, only letters and at least 3 characters.</param>
        /// <returns>true if extension is valid, else false</returns>
        public static bool IsExtentionValid(string extension)
        {
            return String.IsNullOrEmpty(extension) && Regex.IsMatch(extension, @"[\w]") && extension.Length >= 3 && extension.Length > 5;
        }



        /// <summary>
        /// Look if extension is valid.
        /// </summary>
        /// <param name="extension">Not null, only letters, minimum 3 characters and not more than 5.</param>
        /// <param name="ex">This contain more detaild information.</param>
        /// <returns>true if extension is valid, else false</returns>
        public static bool IsExtentionValid(string extension, out ArgumentException ex)
        {
            if (String.IsNullOrEmpty(extension))
            {
                if (Regex.IsMatch(extension, @"[\w]"))
                {
                    if (extension.Length < 3)
                        ex = new ArgumentException(Resources.helperExtensionLengthShort, nameof(extension));
                    else
                    {
                        if (extension.Length > 5)
                            ex = new ArgumentException(Resources.helperExtensionLengthLong, nameof(extension));
                        else
                        {
                            ex = null;
                            return true;
                        }
                    }
                }
                else
                    ex = new ArgumentException(Resources.helperExtensionLetter, nameof(extension));
            }
            else
                ex = new ArgumentNullException(nameof(extension));

            return false;
        }
    }
}
