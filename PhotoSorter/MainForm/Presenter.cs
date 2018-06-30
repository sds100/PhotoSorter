namespace PhotoSorter.MainForm
{
    class Presenter : IPresenter
    {
        private const string DEBUG_PATH = "A:\\SORT-PHOTOS-TEMP";

        private readonly IForm Form;

        public Presenter(IForm form)
        {
            Form = form;
        }

        public void SortAsync()
        {
            Sorter.SortAsync(DEBUG_PATH, null, null);
        }
    }
}
