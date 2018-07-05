using System;
using System.IO;

namespace PhotoSorter
{
    /// <summary>
    /// Stores the date necessary to sort a file.
    /// </summary>
    public class PhotoInfo
    {
        public string FilePath { get; }
        public DateTime DateTaken { get; }

        public string FileName => Path.GetFileName(FilePath);

        public PhotoInfo(string fileName, DateTime itemDate)
        {
            FilePath = fileName;
            DateTaken = itemDate;
        }
    }
}
