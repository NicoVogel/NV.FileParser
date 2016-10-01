namespace FileParser.Exceptions
{
    /// <summary>
    /// This class contains the event ids of this project
    /// </summary>
    public static class DiagnosticEvents
    {
        public const int Base = 1000;
        public const int DataManagerErrorSave = Base + 1;
        public const int DataManagerErrorLoad = Base + 2;

        public const int HelperErrorPathLength = Base + 10;
        public const int HelperErrorExtensionTooShort = Base + 11;
        public const int HelperErrorExtensionTooLong = Base + 12;
        public const int HelperErrorExtensionNonLetterCharacters = Base + 13;
        public const int HelperErrorExtensionNull = Base + 14;

        public const int ParserErrorBinarySave = Base + 20;
        public const int ParserErrorBinaryLoad = Base + 21;

        public const int ParserErrorJsonSave = Base + 30;
        public const int ParserErrorJsonLoad = Base + 31;

        public const int ParserErrorTextSave = Base + 40;
        public const int ParserErrorTextLoad = Base + 41;

        public const int ParserErrorXmlSave = Base + 50;
        public const int ParserErrorXmlLoad = Base + 51;

    }
}
