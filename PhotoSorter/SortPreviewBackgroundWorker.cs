using Microsoft.WindowsAPICodePack.Shell;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace PhotoSorter
{
    public class SortPreviewBackgroundWorker : BackgroundWorker
    {
        private const string DEBUG_JSON = "../../debug.json";

        public SortPreviewBackgroundWorker()
        {
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);

            var args = (Arguments)e.Argument;
            var sortResult = new SortPreviewResult();

            var photoInfoListResult = CreatePhotoInfoList(args.SourceDirectory, e);
            int totalFileCount = photoInfoListResult.PhotoInfoList.Count;

            sortResult.UnknownFilesList = photoInfoListResult.UnknownFilesList;

            var groupTypes = args.GroupFormats;

            var groups = CreateGroups(
                photoInfoListResult.PhotoInfoList,
                groupTypes,
                eventArgs: e);

            OutputJsonToFile(groups);

            sortResult.GroupInfoList = groups;
            sortResult.OutputDirectory = args.OutputDirectory;

            e.Result = sortResult;
        }

        /// <summary>
        /// Get the name and date taken for all the media files in a directory.
        /// </summary>
        /// <param name="sourceDirectory"></param>
        private PhotoInfoListResult CreatePhotoInfoList(
            string sourceDirectory,
            DoWorkEventArgs eventArgs)
        {
            int checkedFileCount = 0;

            var photoInfoList = new List<PhotoInfo>();

            //a list of paths to all files which can't be sorted
            var unknownFilesList = new List<string>();
            var filesInDirectory = Directory.GetFiles(sourceDirectory);

            //loop through the file names of every file in the source directory
            foreach (string filePath in filesInDirectory)
            {
                if (CancellationPending)
                {
                    eventArgs.Cancel = true;
                    break;
                }

                using (var file = ShellFile.FromFilePath(filePath))
                {
                    /*The date the photo or video was taken. For photos, it is the "Date Taken" 
                     property and for videos it is the "Media Created" property*/
                    var itemDate = file.Properties.System.ItemDate.Value;

                    if (itemDate.HasValue)
                    {
                        photoInfoList.Add(new PhotoInfo(filePath, itemDate.GetValueOrDefault()));
                    }
                    else
                    {
                        unknownFilesList.Add(filePath);
                    }
                }

                checkedFileCount++;

                var percentProgress = CalculatePercentageComplete(
                    checkedFileCount,
                   filesInDirectory.Length);

                ReportProgress(percentProgress);
            }

            return new PhotoInfoListResult(photoInfoList, unknownFilesList);
        }

        /// <summary>
        /// Loop through all the files which want to be sorted then create the groups (folders)
        /// necessary to sort them.
        /// </summary>
        private List<Group> CreateGroups(
            List<PhotoInfo> photoInfoList,
            List<string> groupFormats,
            DoWorkEventArgs eventArgs)
        {
            var groupList = new List<Group>();

            for (int i = 0; i < photoInfoList.Count; i++)
            {
                if (CancellationPending)
                {
                    eventArgs.Cancel = true;
                    break;
                }

                var photoInfo = photoInfoList[i];
                var format = groupFormats[0];

                GroupName groupName = new GroupName(photoInfo.DateTaken, format);

                //If no suitable group for the item already exists then create the group
                if (!groupList.Any(item => item.Name == groupName))
                {
                    var group = new Group(groupName);

                    //If not at the lowest level of the group tree, create child groups
                    if (groupFormats.Count > 1)
                    {
                        var childGroupFormats = groupFormats.ToList();

                        // remove the current group from the child groups
                        childGroupFormats.RemoveAt(0);

                        //only select files for the child group which can go in that group
                        var childPhotoInfoList =
                            photoInfoList.Where(photo =>
                            photo.DateTaken.ToString(format)
                            == groupName.ToString()).ToList();

                        /*remove all the files which will go into the next group from the
                          parent group's list of files*/
                        childPhotoInfoList.ForEach(item => photoInfoList.Remove(item));

                        group.ChildrenGroups =
                            CreateGroups(
                                childPhotoInfoList,
                                childGroupFormats,
                                eventArgs);
                    }
                    else
                    {
                        //only put files in the group that actually belong in the group
                        var files = photoInfoList.Where(photo =>
                            photo.DateTaken.ToString(format)
                            == groupName.ToString()).ToList();

                        group.Files = files;

                    }

                    groupList.Add(group);
                }
            }

            groupList.Sort();

            return groupList;
        }

        private static int CalculatePercentageComplete(int checkedFileCount, int totalFileCount)
        {
            return (int)(((float)checkedFileCount / totalFileCount) * 100);
        }

        private static void OutputJsonToFile(object value)
        {
            using (var streamWriter = new StreamWriter(DEBUG_JSON))
            {
                streamWriter.Write(JsonConvert.SerializeObject(value));
            }
        }

        public struct Arguments
        {
            public readonly string SourceDirectory;
            public readonly string OutputDirectory;
            public readonly List<string> GroupFormats;

            public Arguments(
                string sourceDirectory,
                string outputDirectory,
                List<string> groupFormats
                )
            {
                SourceDirectory = sourceDirectory;
                OutputDirectory = outputDirectory;
                GroupFormats = groupFormats;
            }
        }
    }
}
