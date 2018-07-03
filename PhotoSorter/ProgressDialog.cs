using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PhotoSorter
{
    public partial class ProgressDialog : Form, IProgressDialog
    {
        public event EventHandler DialogCancelled;

        public ProgressDialog(string title)
        {
            InitializeComponent();

            this.Text = title;
        }

        public void OnStatusChange(string message)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                labelStatus.Text = message;
            }));
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogCancelled(this, new EventArgs());

            this.Close();
        }

        public void OnWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Close() doesn't close the form from view.
            this.Dispose();
        }

        public void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    progressBar.Value = e.ProgressPercentage;
                }));
            }
            catch (Exception) { };
        }

        public void SubscribeToBackgroundWorker(BackgroundWorker worker)
        {
            //subscribe to BackgroundWorker events
            worker.RunWorkerCompleted += this.OnWorkerCompleted;
            worker.ProgressChanged += this.OnProgressChanged;

            //When this dialog is cancelled, cancel the worker.
            this.DialogCancelled += delegate { worker.CancelAsync(); };
        }

        /// <summary>
        /// Cancel the dialog if the user closes the window
        /// </summary>
        private void ProgressDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogCancelled(this, new EventArgs());
        }
    }
}
