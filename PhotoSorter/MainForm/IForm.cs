using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhotoSorter.MainForm
{
    interface IForm
    {
        List<string> SourceDirectories { get; }
        string OutputDirectory { get; set; }
        bool IncludeSubDirectories { get; }
        List<string> SelectedGroupFormats { get; }
        
        void ShowMessage(string message, bool isError);
        void OnSortPreviewComplete(object sender, RunWorkerCompletedEventArgs e);
    }
}
