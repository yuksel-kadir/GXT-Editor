using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTXEditor
{
    public static class Constants
    {
        public const string EXE_PATH = @"\Compiler\gxt.exe";
        public const string MISSION_TABLE_REGEX = @"^{=+ MISSION TABLE (.+) =+}$";

        public const string CURRENT_FILE_LABEL = "Current Text File Path: ";
        public const string PREVIEW_TEXT = "Preview Text";
        public const string MISSION_TABLE_LINE = "{=================================== MISSION TABLE AMBULAE ===================================}";
        public const string PLACEHOLDER_TEXT = "Placeholder Text";

        public const string GTA_SA_DECOMPILE_ARGUMENTS = " -k CRC32 -w0 -h1";
        public const string GTA_IV_DECOMPILE_ARGUMENTS = " -h1 -k JENKINS -m0";

        public const string TEXT_FILE_FILTER = "Text Files|*.txt";
        public const string GXT_FILE_FILTER = "GXT Files|*.gxt";

        public const int GXT_KEY_COLUMN = 0;
        public const int GXT_VALUE_COLUMN = 1;

        public static readonly string[] fontNames = { "Bank Gothic", "Beckett", "GTA VC Regular", "Old English", "Rage Italic" };
    }
}
