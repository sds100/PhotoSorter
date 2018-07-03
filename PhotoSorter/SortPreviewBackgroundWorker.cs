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

            var groupTypes = args.GroupTypes;

            var groups = CreateGroups(
                photoInfoListResult.PhotoInfoList,
                groupTypes,
                eventArgs: e);

            OutputJsonToFile(groups);

            sortResult.GroupInfoList = groups;

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
            List<GroupType> groupTypes,
            DoWorkEventArgs eventArgs)
        {
            var groupType = groupTypes[0];
            var groupList = new List<Group>();

            for (int i = 0; i < photoInfoList.Count; i++)
            {
                if (CancellationPending)
                {
                    eventArgs.Cancel = true;
                    break;
                }

                var photoInfo = photoInfoList[i];

                string datePart = GetDatePartByGroupType(photoInfo, groupType);

                //If no suitable group for the item already exists then create the group
                if (!groupList.Any(item => item.Name == datePart && item.Type == groupType))
                {
                    var group = new Group(datePart, groupType);

                    //If not at the lowest level of the group tree, create child groups
                    if (groupTypes.Count > 1)
                    {
                        var childGroupTypes = groupTypes.ToList();

                        // remove the current group from the child groups
                        childGroupTypes.RemoveAt(0);

                        //only select files for the child group which can go in that group
                        var childPhotoInfoList =
                            photoInfoList.Where(photo =>
                            GetDatePartByGroupType(photo, groupType) == datePart).ToList();

                        /*remove all the files which will go into the next group from the
                          parent group's list of files*/
                        childPhotoInfoList.ForEach(item => photoInfoList.Remove(item));

                        group.ChildrenGroups =
                            CreateGroups(
                                childPhotoInfoList,
                                childGroupTypes,
                                eventArgs);
                    }
                    else
                    {
                        //only put files in the group that actually belong in the group
                        var files = photoInfoList.Where(
                            photo => GetDatePartByGroupType(photo, groupType) == datePart
                            ).ToList();

                        group.Files = files;

                    }

                    groupList.Add(group);
                }
            }


            return groupList;
        }

        /// <summary>
        /// Determines the name of a group by extracting the correct part of the date of the file
        /// depending on the group type. E.g if the group type is YEAR then it will extract the
        /// year from the date of the file..
        /// </summary>
        /// <param name="photoInfo"></param>
        /// <param name="groupType"></param>
        /// <returns></returns>
        private static string GetDatePartByGroupType(PhotoInfo photoInfo, GroupType groupType)
        {
            var dateTime = photoInfo.DateTaken;

            switch (groupType)
            {
                case GroupType.YEAR:
                    return dateTime.Year.ToString();

                case GroupType.MONTH:
                    return dateTime.ToString("MMMM");

                case GroupType.DAY:
                    return dateTime.Day.ToString();

                case GroupType.HOUR:
                    return dateTime.Hour.ToString();

                default:
                    return null;
            }
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
            public readonly List<GroupType> GroupTypes;

            public Arguments(
                string sourceDirectory,
                List<GroupType> groupTypes
                )
            {
                SourceDirectory = sourceDirectory;
                GroupTypes = groupTypes;
            }
        }
    }
}
