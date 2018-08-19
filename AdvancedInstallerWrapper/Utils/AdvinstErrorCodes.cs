using System.Collections.Generic;

namespace AdvancedInstallerWrapper.Utils
{
    public static class AdvinstErrorCodes
    {
        private static readonly Dictionary<uint, string> _errorCodeDictionary = new Dictionary<uint, string>()
        {
            { 0, "returned when a command is executed successfully"},
            { 0xE0010064 , "returned when an exception occurs and no other error code is specified"},
            { 0xE0010065 , "invalid MSI identifier"},
            { 0xE0010066, "duplicated search signature"},
            { 0xE0010067, "search signature was not found"},
            { 0xE0010068, "file is missing"},
            { 0xE0010069, "command line is invalid"},
            { 0xE001006A, "command file format is invalid (possible unsupported encoding)" },
            { 0xE001006B, "the date is invalid MS DOS date"},
            { 0xE001006C, "user does not have license to build the project and trial has expired" },
            { 0xE001006D, "unable to acquire a floating license (no slots or unable to contact the license server)" }

        };

        public static Dictionary<uint, string> ErrorCodes
        {
            get
            {
                return _errorCodeDictionary;
            }
        }
    }
}
