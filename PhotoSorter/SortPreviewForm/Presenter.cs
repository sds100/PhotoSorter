namespace PhotoSorter.SortPreviewForm
{
    class Presenter : IPresenter
    {
        private readonly IForm Form;

        public Presenter(IForm form, SortPreviewResult sortPreviewResult)
        {
            Form = form;
            Form.AddNodesToTree(sortPreviewResult.UnknownFilesList, sortPreviewResult.GroupInfoList);
        }
    }
}
