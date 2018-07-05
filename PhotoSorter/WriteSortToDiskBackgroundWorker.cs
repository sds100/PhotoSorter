using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSorter
{
    class WriteSortToDiskBackgroundWorker : BackgroundWorker
    {
        public WriteSortToDiskBackgroundWorker()
        {
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);

            var args = (Arguments)e.Argument;

            WriteSortedListToDisk(args.GroupList, args.OutputDirectory, args.MoveOrCopy, e);
        }

        private void WriteSortedListToDisk(
            List<Group> groupList,
            string parentDirectory,
            int moveOrCopy,
            DoWorkEventArgs eventArgs)
        {
            foreach (var group in groupList)
            {
                if (CancellationPending)
                {
                    eventArgs.Cancel = true;
                    break;
                }

                string directory = $"{parentDirectory}\\{group.Name}";
                Directory.CreateDirectory(directory);

                if (group.HasChildrenGroups)
                {
                    WriteSortedListToDisk(group.ChildrenGroups, directory, moveOrCopy, eventArgs);
                }

                if (group.HasFiles)
                {
                    if (moveOrCopy == SortPreviewForm.SortPreviewForm.COPY)
                    {
                        foreach (var file in group.Files)
                        {
                            File.Copy(file.FilePath, $"{directory}\\{file.FileName}");
                        }
                    }
                    else
                    {
                        foreach (var file in group.Files)
                        {
                            File.Move(file.FilePath, $"{directory}\\{file.FileName}");
                        }
                    }
                }
            }
        }

        public struct Arguments
        {
            public readonly string OutputDirectory;
            public readonly List<Group> GroupList;
            public readonly int MoveOrCopy;

            public Arguments(
                string outputDirectory,
                int moveOrCopy,
                List<Group> groupList
                )
            {
                OutputDirectory = outputDirectory;
                MoveOrCopy = moveOrCopy;
                GroupList = groupList;
            }
        }
    }
}
