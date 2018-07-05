using System.Collections.Generic;
using System.IO;

namespace PhotoSorter.SortPreviewForm
{
    class Presenter : IPresenter
    {
        private readonly IForm Form;
        private readonly List<Group> GroupList;
        private readonly string OutputDirectory;

        public Presenter(IForm form, SortPreviewResult sortPreviewResult)
        {
            Form = form;
            GroupList = sortPreviewResult.GroupInfoList;
            OutputDirectory = sortPreviewResult.OutputDirectory;

            Form.AddNodesToTree(
                sortPreviewResult.UnknownFilesList,
                sortPreviewResult.GroupInfoList);
        }

        public void Sort(IProgressDialog progressDialog)
        {
            var backgroundWorker = new WriteSortToDiskBackgroundWorker();

            var args = new WriteSortToDiskBackgroundWorker.Arguments(
                OutputDirectory,
                Form.MoveOrCopy,
                GroupList
                );

            progressDialog.SubscribeToBackgroundWorker(backgroundWorker);

            backgroundWorker.RunWorkerCompleted += delegate { Form.OnProgressCompleted(); };

            backgroundWorker.RunWorkerAsync(args);

            progressDialog.Show();
        }
    }
}
