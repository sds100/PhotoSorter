using Microsoft.WindowsAPICodePack.Shell;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static PhotoSorter.Group;

namespace PhotoSorter
{
    public static class Sorter
    {
        private const string DEBUG_JSON = "../../debug.json";

        /// <summary>
        /// Sort photos into groups but don't write the changes to the disk.
        /// </summary>
        /// <param name="sourceDirectory">Directory where the photos to sort are located</param>
        /// <param name="groupTypes">The types of groups to sort the photos into.
        /// E.g year, month, day</param>
        public static async Task<SortResult> SortPreviewAsync(
            string sourceDirectory,
            GroupType[] groupTypes)
        {
            var sortResult = new SortResult();

            await Task.Run(() =>
            {

                var fileInfoListResult = CreatePhotoInfoList(sourceDirectory);
                sortResult.UnknownFiles = fileInfoListResult.UnknownFiles;

                var groups = CreateGroups(
                    fileInfoListResult.PhotoInfoList,
                    GroupType.YEAR,
                    groupTypes.ToList());

                OutputJsonToFile(groups);
            });

            return sortResult;
        }

        /// <summary>
        /// Get the name and date taken for all the media files in a directory.
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <returns></returns>
        private static PhotoInfoListResult CreatePhotoInfoList(string sourceDirectory)
        {
            var photoInfoList = new List<PhotoInfo>();
            bool unknownFiles = false;

            //loop through the file names of every file in the source directory
            foreach (string fileName in Directory.GetFiles(sourceDirectory))
            {
                using (var file = ShellFile.FromFilePath(fileName))
                {
                    ///
                    var itemDate = file.Properties.System.ItemDate.Value;

                    if (itemDate.HasValue)
                    {
                        photoInfoList.Add(new PhotoInfo(fileName, itemDate.GetValueOrDefault()));
                    }
                }
            }

            return new PhotoInfoListResult(photoInfoList, unknownFiles);
        }

        private static List<Group> CreateGroups(
            List<PhotoInfo> photoInfoList,
            GroupType groupType,
            List<GroupType> childGroupTypes)
        {
            var groupList = new List<Group>();

            foreach (var photoInfo in photoInfoList)
            {
                string datePart = GetDatePartByGroupType(photoInfo, groupType);

                if (groupType == GroupType.YEAR) {
                    Console.WriteLine(photoInfoList.Count);
                }

                //If no suitable group for the item already exists then create the group
                if (!groupList.Any(item => item.Name == datePart && item.Type == groupType))
                {
                    var group = new Group(datePart, groupType);

                    //If not at the lowest level of the group tree, create child groups
                    if (childGroupTypes.Count > 1)
                    {
                        // remove the current group from the child groups
                        childGroupTypes.RemoveAt(0);

                        //only select files for the child group which can go in that group
                        var childPhotoInfoList =
                            photoInfoList.Where(item =>
                            GetDatePartByGroupType(item, groupType) == datePart).ToList();

                        group.ChildGroups =
                            CreateGroups(childPhotoInfoList, childGroupTypes[0], childGroupTypes);
                    }

                    groupList.Add(group);
                }
            }

            return groupList;
        }

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

                default:
                    return null;
            }
        }

        private static void OutputJsonToFile(object value)
        {
            using (var streamWriter = new StreamWriter(DEBUG_JSON))
            {
                streamWriter.Write(JsonConvert.SerializeObject(value));
            }
        }
    }
}
