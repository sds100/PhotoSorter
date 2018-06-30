namespace PhotoSorter
{
    public interface IProgressBar
    {
        void OnProgress(int percent);
        void OnProgressFinish();
    }
}
