using System.Collections.Generic;
using System.IO;

namespace PhotoSorter.MainForm
{
    class Presenter : IPresenter
    {
        private readonly IForm Form;

        public Presenter(IForm form)
        {
            Form = form;
        }

        public void SortPreview(bool inDebugMode, IProgressDialog progressDialog)
        {
            var groupTypes = Form.SelectedGroupTypes;
            string sourceDirectory = Form.SourceDirectory;

            if (inDebugMode)
            {
                groupTypes = new List<GroupType>()
                {
                    GroupType.YEAR,
                    GroupType.MONTH,
                    GroupType.DAY,
                    GroupType.HOUR
                };

                sourceDirectory = MainForm.DEBUG_SOURCE;
            }
            else if (!AreOptionsValid())
            {
                return;
            }

            var backgroundWorker = new SortPreviewBackgroundWorker();

            var args = new SortPreviewBackgroundWorker.Arguments(
                sourceDirectory,
                groupTypes
                );

            progressDialog.SubscribeToBackgroundWorker(backgroundWorker);

            backgroundWorker.RunWorkerCompleted += Form.OnSortPreviewComplete;

            backgroundWorker.RunWorkerAsync(args);

        }

        private bool AreOptionsValid()
        {
            if (string.IsNullOrWhiteSpace(Form.SourceDirectory)
                || !Directory.Exists(Form.SourceDirectory))
            {
                Form.ShowMessage("Must choose a valid source directory", isError: true);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Form.OutputDirectory)
                || !Directory.Exists(Form.OutputDirectory))
            {
                Form.ShowMessage("Must choose a valid output directory", isError: true);
                return false;
            }
            else if (Form.SelectedGroupTypes.Count == 0)
            {
                Form.ShowMessage("Must choose at least one group", isError: true);
                return false;
            }

            return true;
        }
    }
}
