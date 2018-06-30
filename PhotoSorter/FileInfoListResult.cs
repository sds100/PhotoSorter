using System.Collections.Generic;

namespace PhotoSorter
{
    public struct FileInfoListResult
    {
        public List<FileInfo> FileInfoList { get; }
        public bool UnknownFiles { get; }

        public FileInfoListResult(List<FileInfo> fileInfoList, bool unknownFiles)
        {
            FileInfoList = fileInfoList;
            UnknownFiles = unknownFiles;
        }
    }
}
