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

        public async void SortPreviewAsync(bool inDebugMode)
        {
            var groupTypes = Form.SelectedGroupTypes;

            if (inDebugMode)
            {
                groupTypes = new List<GroupType>()
                {
                    GroupType.YEAR,
                    GroupType.MONTH,
                    GroupType.DAY,
                    GroupType.HOUR
                };

                string sourceDirectory = MainForm.DEBUG_SOURCE;

                await Sorter.SortPreviewAsync(sourceDirectory, groupTypes);

                return;
            }

            if (AreOptionsValid())
            {
                await Sorter.SortPreviewAsync(Form.SourceDirectory, groupTypes);
            }
        }

        public void SortPreviewAsync() => SortPreviewAsync(inDebugMode: false);

        private bool AreOptionsValid()
        {
            if (string.IsNullOrWhiteSpace(Form.SourceDirectory)
                || !Directory.Exists(Form.SourceDirectory))
            {
                Form.ShowErrorMessage("Must choose a valid source directory");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Form.OutputDirectory)
                || !Directory.Exists(Form.OutputDirectory))
            {
                Form.ShowErrorMessage("Must choose a valid output directory");
                return false;
            }
            else if (Form.SelectedGroupTypes.Count == 0)
            {
                Form.ShowErrorMessage("Must choose at least one group");
                return false;
            }

            return true;
        }
    }
}
