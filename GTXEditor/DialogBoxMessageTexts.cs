

namespace GTXEditor
{
    public static class DialogBoxMessageTexts
    {
        //DIALOG BOX TITLE
        public const string TITLE_SELECT_GXT_FILE = "Select a GXT File";
        public const string TITLE_SAVE_TEXT_FILE = "Save a GXT File";
        public const string TITLE_GXT_KEY_NOT_FOUND = "GXT Key Not Found";
        public const string TITLE_GXT_VALUE_NOT_FOUND = "GXT Value Not Found";
        public const string TITLE_ERROR_OCCURED = "Error Occurred";
        public const string TITLE_WARNING = "Warning";
        public const string TITLE_ERROR = "Error";
        public const string TITLE_INFO = "Information";

        //ERROR
        public const string ERROR_OCCURRED = "An error occurred: {0}";
        public const string ERROR_OCCURRED_FILE_SAVE = "An error occurred while saving txt file: {0}";
        public const string BAD_ALLOCATION = "Decompiling failed: Bad Allocation. Couldn't decompile the gxt file. Maybe selected wrong game for the gxt file?";
        public const string DECOMPILING_FAILED_WITH = "Decompiling failed with exit code: {0}";
        public const string SOMETHING_WENT_WRONG = "Something went wrong: {0}";

        //INFO
        public const string PATH_COPIED_TO_CLIPBOARD = "'{0}' path copied to clipboard.";
        public const string GXT_TABLE_SAVED_TO = "GXT table is saved to: {0}";

        //WARNING
        public const string OPEN_GXT_FILE = "Please open a GXT file first.";
        
        //WARNING SEARCH RELATED
        public const string KEY_NOT_FOUND = "Key not found.";
        public const string VALUE_NOT_FOUND = "Value not found.";

        public static string GetFormattedText(string message, params object[] args)
        {
            return string.Format(message, args);
        }
    }
}
