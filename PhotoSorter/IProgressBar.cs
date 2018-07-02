namespace PhotoSorter
{
    public interface IProgressBar
    {
        void OnReportProgress(int percent);
        void OnProgressCompleted();
    }
}
