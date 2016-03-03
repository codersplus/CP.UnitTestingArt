using System;
using LogAn.Interfaces;

namespace LogAn.Classes
{
    public class LogAnalyzer
    {
        private readonly IFileExtensionManager _fileExtensionManager ;
        public LogAnalyzer(IFileExtensionManager fileExtensionManager)
        {
            _fileExtensionManager = fileExtensionManager;
        }

        public bool IsValidLogFileName(string fileName)
        {
           return  _fileExtensionManager.IsValid(fileName);
        }

    }
}
