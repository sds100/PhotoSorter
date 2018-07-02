using System.Collections.Generic;

namespace PhotoSorter.SortPreviewForm
{
    interface IForm
    {
        void AddNodesToTree(List<string> unknownFiles, List<Group> groupList);
    }
}
