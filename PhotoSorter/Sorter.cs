using Microsoft.WindowsAPICodePack.Shell;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static PhotoSorter.Group;

namespace PhotoSorter
{
    /// <summary>
    /// Class that controls sorting files.
    /// </summary>
    public static class Sorter
    {
        private const string DEBUG_JSON = "../../debug.json";

        /// <summary>
        /// Sort photos into groups but don't write the changes to the disk.
        /// </summary>
        /// <param name="sourceDirectory">Directory where the photos to sort are located</param>
        /// <param name="groupTypes">The types of groups to sort the photos into.
        /// E.g year, month, day</param>
        public static async Task<SortPreviewResult> SortPreviewAsync(
            string sourceDirectory,
            GroupType[] groupTypes)
        {
            var sortResult = new SortPreviewResult();

            await Task.Run(() =>
            {
                var photoInfoListResult = CreatePhotoInfoList(sourceDirectory);

                sortResult.UnknownFilesList = photoInfoListResult.UnknownFilesList;
                sortResult.PhotoInfoList = photoInfoListResult.PhotoInfoList;

                var groups = CreateGroups(
                    photoInfoListResult.PhotoInfoList,
                    GroupType.YEAR,
                    groupTypes.ToList());
            });

            return sortResult;
        }

        /// <summary>
        /// Get the name and date taken for all the media files in a directory.
        /// </summary>
        /// <param name="sourceDirectory"></param>
        private static PhotoInfoListResult CreatePhotoInfoList(string sourceDirectory)
        {
            var photoInfoList = new List<PhotoInfo>();

            //a list of paths to all files which can't be sorted
            var unknownFilesList = new List<string>();

            //loop through the file names of every file in the source directory
            foreach (string filePath in Directory.GetFiles(sourceDirectory))
            {
                using (var file = ShellFile.FromFilePath(filePath))
                {
                    /*The date the photo or video was taken. For photos, it is the "Date Taken" 
                     property and for videos it is the "Media Created" property*/
                    var itemDate = file.Properties.System.ItemDate.Value;

                    if (itemDate.HasValue)
                    {
                        photoInfoList.Add(new PhotoInfo(filePath, itemDate.GetValueOrDefault()));
                    }
                    else {
                        unknownFilesList.Add(filePath);
                    }
                }
            }

            return new PhotoInfoListResult(photoInfoList, unknownFilesList);
        }

        /// <summary>
        /// Loop through all the files which want to be sorted then create the groups (folders)
        /// necessary to sort them.
        /// </summary>
        /// <param name="photoInfoList"></param>
        /// <param name="groupType"></param>
        /// <param name="groupTypes"></param>
        /// <returns></returns>
        private static List<Group> CreateGroups(
            List<PhotoInfo> photoInfoList,
            GroupType groupType,
            List<GroupType> groupTypes)
        {
            var groupList = new List<Group>();

            foreach (var photoInfo in photoInfoList)
            {
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
