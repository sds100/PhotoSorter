using System;

namespace PhotoSorter
{
    /// <summary>
    /// Stores the date necessary to sort a file.
    /// </summary>
    public struct PhotoInfo
    {
        public string FileName { get; }
        public DateTime DateTaken { get; }

        public PhotoInfo(string fileName, DateTime itemDate)
        {
            FileName = fileName;
            DateTaken = itemDate;
        }
    }
}
