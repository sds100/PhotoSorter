using System.Collections.Generic;

namespace PhotoSorter.SortPreviewForm
{
    interface IForm
    {
        int MoveOrCopy { get; }
        void OnProgressCompleted();
        void AddNodesToTree(List<string> unknownFiles, List<Group> groupList);
    }
}
