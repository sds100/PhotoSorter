namespace PhotoSorter.MainForm
{
    interface IPresenter
    {
        void SortPreviewAsync();
        void SortPreviewAsync(bool inDebugMode);
    }
}
