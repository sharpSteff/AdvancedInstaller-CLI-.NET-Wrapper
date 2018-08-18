using System.Collections.Generic;

namespace AdvancedInstallerWrapper.Utils
{
    public static class AdvinstErrorCodes
    {
        private static readonly Dictionary<string, string> _errorCodeDictionary = new Dictionary<string, string>()
        {
            {"AI_NO_ERORR (0)", "returned when a command is executed successfully"},
            {"AI_ERROR_EXCEPTION (0xE0010064)" , "returned when an exception occurs and no other error code is specified"},
            {"AI_ERROR_BAD_IDENTIFIER (0xE0010065)", "invalid MSI identifier"},
            {"AI_ERROR_DUPLICATED_SEARCH_SIGNATURE (0xE0010066)", "duplicated search signature"},
            {"AI_ERROR_SEARCH_NOT_FOUND (0xE0010067)", "search signature was not found"},
            {"AI_ERROR_FILE_NOT_FOUND (0xE0010068)", "file is missing"},
            {"AI_ERROR_MALFORMED_COMMAND_LINE (0xE0010069)", "command line is invalid"},
            {"AI_ERROR_UNSUPPORTED_CMD_FILE_FORMAT (0xE001006A)", "command file format is invalid (possible unsupported encoding)" },
            { "AI_ERROR_INVALID_MS_DOS_DATE (0xE001006B)", "the date is invalid MS DOS date"},
            { "AI_ERROR_NO_LICENSE (0xE001006C)", "user does not have license to build the project and trial has expired" },
            {"AI_ERROR_NO_FLOATING_LICENSE (0xE001006D)", "unable to acquire a floating license (no slots or unable to contact the license server)" }

        };

        public static Dictionary<string, string> ErrorCodes
        {
            get
            {
                return _errorCodeDictionary;
            }
        }
    }
}
