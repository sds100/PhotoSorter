using System.Collections.Generic;

namespace PhotoSorter
{
    public struct PhotoInfoListResult
    {
        public List<PhotoInfo> PhotoInfoList { get; }
        public bool UnknownFiles { get; }

        public PhotoInfoListResult(List<PhotoInfo> photoInfoList, bool unknownFiles)
        {
            PhotoInfoList = photoInfoList;
            UnknownFiles = unknownFiles;
        }
    }
}
