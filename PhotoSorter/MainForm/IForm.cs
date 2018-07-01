using System.Collections.Generic;
using static PhotoSorter.Group;

namespace PhotoSorter.MainForm
{
    interface IForm
    {
        IProgressBar ProgressBar { get; }

        string SourceDirectory { get; set; }
        string OutputDirectory { get; set; }
        List<GroupType> SelectedGroupTypes { get; }

        void ShowErrorMessage(string message);
    }
}
