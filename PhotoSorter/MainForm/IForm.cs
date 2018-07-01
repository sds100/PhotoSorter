namespace PhotoSorter.MainForm
{
    interface IForm
    {
        string SourceDirectory { get; set; }
        string OutputDirectory { get; set; }
        IProgressBar ProgressBar { get; }
        void ShowErrorMessage(string message);
    }
}
