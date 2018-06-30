using System;

namespace PhotoSorter
{
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
