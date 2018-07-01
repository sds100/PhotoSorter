using PhotoSorter.Properties;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoSorter.MainForm
{
    public partial class MainForm : Form, IForm, IProgressBar
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

        public IProgressBar ProgressBar => this;

        public List<GroupType> SelectedGroupTypes
        {
            get
            {
                var selectedGroupTypes = new List<GroupType>();

                foreach (var checkedItem in listBoxGroups.CheckedItems)
                {
                    selectedGroupTypes.Add(
                        Group.GroupTitles.First(item => item.Value == (string)checkedItem).Key);
                }

                return selectedGroupTypes;
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
            ShowGroupTypesInListView();
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

        public void OnProgress(int percent)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                progressBar.Value = percent;
            }));
        }

        public void OnProgressFinish()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                progressBar.Value = 0;
            }));
        }

        public void ShowErrorMessage(string message)
        {
            labelStatus.Text = message;
            labelStatus.ForeColor = Color.Red;
        }

        public void ShowSortPreviewDialog(SortPreviewResult sortPreviewResult)
        {
            new SortPreviewForm.SortPreviewForm(sortPreviewResult).ShowDialog();
        }

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            //Only run in debug mode if the build configuration is Debug
#if DEBUG
            Presenter.SortPreviewAsync(inDebugMode: true);
            return;
#endif
            Presenter.SortPreviewAsync();
        }

        private void ShowGroupTypesInListView()
        {
            var groupTitles = Group.GroupTitles.Select(item => item.Value);

            var items = listBoxGroups.Items;
            items.AddRange(groupTitles.ToArray());
        }
    }
}
