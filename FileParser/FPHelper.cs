using System;
using System.Text.RegularExpressions;

using FileParser.Properties;
using FileParser.Exceptions;
using ExceptionObserver;

namespace FileParser
{
    /// <summary>
    /// This class helps to provent errors.
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
        /// <param name="ex">return an <see cref="FPException"/> object that can be thrown.</param>
        /// <returns>true if everything is ok, false if not.</returns>
        public static bool IsPathValid(string path, out FPException ex)
        {
            int length = 255;
            if (path.Length > length)
            {
                ex = new FPPathLengthException(String.Format(Resources.helperPathLenght, length.ToString(), path) + "\n" + Resources.exceptionMoreInformation);
                ex.Data.Add("path", path);
                ex.Data.Add("maxLength", length);
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
        /// <param name="ex">return an <see cref="FPException"/> object that can be thrown.</param>
        /// <returns>true if extension is valid, else false</returns>
        public static bool IsExtentionValid(string extension, out FPException ex)
        {
            string pattern = @"[\w]";
            int minLength = 3;
            int maxLength = 5;
            if (String.IsNullOrEmpty(extension))
            {
                if (Regex.IsMatch(extension, pattern))
                {
                    if (extension.Length < minLength)
                    {
                        ex = new FPExtensionLengthException(String.Format(Resources.helperExtensionLengthShort, minLength) + "\n" + Resources.exceptionMoreInformation);
                        ex.Data.Add("extension", extension);
                        ex.Data.Add("minLength", minLength);
                    }
                    else
                    {
                        if (extension.Length > maxLength)
                        {
                            ex = new FPExtensionLengthException(String.Format(Resources.helperExtensionLengthLong, maxLength) + "\n" + Resources.exceptionMoreInformation);
                            ex.Data.Add("extension", extension);
                            ex.Data.Add("maxLength", maxLength);
                        }
                        else
                        {
                            ex = null;
                            return true;
                        }
                    }
                }
                else
                {
                    ex = new FPExtensionNonLetterException(Resources.helperExtensionLetter + "\n" + Resources.exceptionMoreInformation);
                    ex.Data.Add("regex", pattern);
                }
            }
            else
                ex = new FPExtenstionNullException(Resources.helperExtensionNull);

            return false;
        }



        /// <summary>
        /// This method can be used to set the extensions for the parser.
        /// It returns the extension if everything is ok, otherwise it throw an excetion and notify the observer.
        /// </summary>
        /// <param name="extension">this string get checked</param>
        /// <param name="observer">can be null</param>
        /// <returns>Returns the <paramref name="extension"/> if it is valid.</returns>
        public static string SetExtenstionManager(string extension, IExceptionObserver observer)
        {
            FPException ex;
            if (IsExtentionValid(extension, out ex))
            {
                return extension;
            }
            else
            {
                if (observer != null)
                    observer.Notify(new ExceptionNotification(ex));
                throw ex;
            }
        }
    }
}
