using System.Collections.Generic;

namespace PhotoSorter
{
    /// <summary>
    /// The result after attempting to choose out all the files out of a directory that
    /// can be sorted
    /// </summary>
    public struct PhotoInfoListResult
    {
        /// <summary>
        /// A list of all the files that can be sorted
        /// </summary>
        public List<PhotoInfo> PhotoInfoList { get; }

        /// <summary>
        /// A list of all the files that can not be sorted
        /// </summary>
        public List<string> UnknownFilesList { get; }

        public bool UnknownFilesFound => UnknownFilesList.Count > 0;

        public PhotoInfoListResult(
            List<PhotoInfo> photoInfoList,
            List<string> unknownFilesList)
        {
            PhotoInfoList = photoInfoList;
            UnknownFilesList = unknownFilesList;
        }
    }
}
