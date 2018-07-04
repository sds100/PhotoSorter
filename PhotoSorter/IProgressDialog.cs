using System.ComponentModel;

namespace PhotoSorter
{
    interface IProgressDialog
    {
        void SubscribeToBackgroundWorker(BackgroundWorker worker);
        void Show();
    }
}
