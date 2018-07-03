namespace PhotoSorter
{
    public interface IProgressBar
    {
        /// <summary>
        /// Show a message describing what is currently happening
        /// </summary>
        void OnStatusChange(string message);
        
        void OnReportProgress(int percent);
        void OnProgressCompleted();
    }
}
