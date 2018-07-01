using System.Collections.Generic;

namespace PhotoSorter
{
    /// <summary>
    /// Stores data required to preview the sort
    /// </summary>
    public struct SortPreviewResult
    {
        /// <summary>
        /// A list of all the files that can be sorted
        /// </summary>
        public List<PhotoInfo> PhotoInfoList { get; set; }

        /// <summary>
        /// A list of all the files that can not be sorted
        /// </summary>
        public List<string> UnknownFilesList { get; set; }

        public bool UnknownFilesFound => UnknownFilesList.Count > 0;
    }
}
