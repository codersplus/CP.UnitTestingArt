using System;
using LogAn.Interfaces;

namespace LogAn.Classes
{
    public class FileExtensionManager : IFileExtensionManager
    {
        public bool IsValid(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("file name has to be provided"); 
            }

            return fileName.EndsWith(".SLF",StringComparison.CurrentCultureIgnoreCase);
        }
    }
}