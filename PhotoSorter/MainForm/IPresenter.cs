namespace PhotoSorter.MainForm
{
    interface IPresenter
    {
        void SortPreview(bool inDebugMode, IProgressDialog progressDialog);
    }
}
