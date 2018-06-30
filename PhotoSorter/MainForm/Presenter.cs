using static PhotoSorter.Group;

namespace PhotoSorter.MainForm
{
    class Presenter : IPresenter
    {
        private const string DEBUG_SOURCE = "A:\\SORT-PHOTOS-TEMP";

        private readonly IForm Form;

        public Presenter(IForm form)
        {
            Form = form;
        }

        public void SortAsync()
        {
            var groupTypes = new GroupType[] { GroupType.YEAR, GroupType.MONTH, GroupType.DAY };

            Sorter.SortAsync(DEBUG_PATH, Form.OutputDirectory, groupTypes);
        }
    }
}
