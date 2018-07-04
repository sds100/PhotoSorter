using PhotoSorter.Properties;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace PhotoSorter.MainForm
{
    public partial class MainForm : Form, IForm
    {
        public const string DEBUG_SOURCE = "../../DEBUG_SOURCE";
        public const string DEBUG_OUTPUT = "../../OUTPUT";

        private readonly IPresenter Presenter;

        public string SourceDirectory
        {
            get => labelSourceDirectory.Text;
            set => labelSourceDirectory.Text = value;
        }

        public string OutputDirectory
        {
            get => labelOutputDirectory.Text;
            set => labelOutputDirectory.Text = value;
        }

        public List<string> SelectedGroupFormats
        {
            get
            {
                var selectedGroupFormats = new List<string>();

                foreach (var checkedItem in listBoxGroups.CheckedItems)
                {
                    selectedGroupFormats.Add(
                        Group.GroupTypeTitles.First(item => item.Value == (string)checkedItem).Key
                        );
                }

                return selectedGroupFormats;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            SourceDirectory = "";
            OutputDirectory = "";

            Presenter = new Presenter(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = $"Version: {Resources.Version}";

            PopulateGroupTypeListView();
        }

        private void ButtonSourceDirectory_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    labelSourceDirectory.Text = dialog.SelectedPath;
                }
            }
        }

        private void ButtonOutputDirectory_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    labelOutputDirectory.Text = dialog.SelectedPath;
                }
            }
        }

        public void ShowMessage(string message, bool isError)
        {
            labelMessage.Text = message;

            if (isError)
            {
                labelMessage.ForeColor = Color.Red;
            }
            else
            {
                labelMessage.ForeColor = Color.Black;
            }
        }

        public void OnSortPreviewComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            // only use the result if the worker wasn't cancelled.
            if (!e.Cancelled)
            {
                var sortPreviewResult = (SortPreviewResult)e.Result;
                new SortPreviewForm.SortPreviewForm(sortPreviewResult).ShowDialog();
            }
        }

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            bool inDebugMode = false;

            //Only run in debug mode if the build configuration is Debug
#if DEBUG
            inDebugMode = true;
#endif
            var progressDialog = new ProgressDialog("Sorting files");

            Presenter.SortPreview(inDebugMode, progressDialog);
        }

        private void PopulateGroupTypeListView()
        {
            var groupTitles = Group.GroupTypeTitles.Select(item => item.Value);

            var items = listBoxGroups.Items;
            items.AddRange(groupTitles.ToArray());
        }
    }
}
