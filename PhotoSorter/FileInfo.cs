using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;

namespace PhotoSorter
{
    public struct FileInfo
    {
        public string FileName { get; }
        public DateTime ItemDate { get; }

        public FileInfo(string fileName, DateTime itemDate)
        {
            FileName = fileName;
            ItemDate = itemDate;
        }
    }
}
