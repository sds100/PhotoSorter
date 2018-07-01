using System.Collections.Generic;
using System.IO;
using static PhotoSorter.Group;

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
            var groupTypes = new List<GroupType>();

            groupTypes.AddRange(
                new GroupType[] { GroupType.YEAR, GroupType.MONTH, GroupType.DAY });

            if (inDebugMode)
            {
                string sourceDirectory = Form.SourceDirectory;

                sourceDirectory = MainForm.DEBUG_SOURCE;

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

            return true;
        }
    }
}
