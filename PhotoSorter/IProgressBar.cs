namespace PhotoSorter
{
    public interface IProgressBar
    {
        void ReportProgress(int percent);
        void OnProgressCompleted();
    }
}
