using System;
using System.Windows.Forms;

namespace PhotoSorter.MainForm
{
    public partial class MainForm : Form, IForm, IProgressBar
    {
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

        public MainForm()
        {
            InitializeComponent();
            Presenter = new Presenter(this);
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

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            Presenter.SortAsync();
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
    }
}
