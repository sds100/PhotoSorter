using System.Collections.Generic;

namespace PhotoSorter.MainForm
{
    interface IForm
    {
        IProgressBar ProgressBar { get; }

        string SourceDirectory { get; set; }
        string OutputDirectory { get; set; }
        List<GroupType> SelectedGroupTypes { get; }

        void ShowSortPreviewDialog(SortPreviewResult sortPreviewResult);
        void ShowMessage(string message, bool isError);
    }
}
