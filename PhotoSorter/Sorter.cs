using Microsoft.WindowsAPICodePack.Shell;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static PhotoSorter.Group;

namespace PhotoSorter
{
    public static class Sorter
    {

        /// <summary>
        /// Sort files into groups but don't write the changes to the disk.
        /// </summary>
        /// <param name="sourceDirectory">Directory where the photos to sort are located</param>
        /// <param name="groupTypes"></param>
        public static async Task<SortResult> SortPreviewAsync(
            string sourceDirectory,
            GroupType[] groupTypes)
        {
            var sortResult = new SortResult();

            await Task.Run(() =>
            {

                var fileInfoListResult = CreateFileInfoList(sourceDirectory);
                sortResult.UnknownFiles = fileInfoListResult.UnknownFiles;

                var groups = CreateGroups(
                    fileInfoListResult.FileInfoList,
                    GroupType.YEAR,
                    groupTypes.ToList());

                OutputJsonToFile(groups);
            });

            return sortResult;
        }

        private static FileInfoListResult CreateFileInfoList(string sourceDirectory)
        {
            var fileInfoList = new List<FileInfo>();
            bool unknownFiles = false;

            //loop through the file names of every file in the source directory
            foreach (string fileName in Directory.GetFiles(sourceDirectory))
            {
                using (var file = ShellFile.FromFilePath(fileName))
                {
                    var itemDate = file.Properties.System.ItemDate.Value;

                    if (itemDate.HasValue)
                    {
                        fileInfoList.Add(new FileInfo(fileName, itemDate.GetValueOrDefault()));
                    }
                }
            }

            return new FileInfoListResult(fileInfoList, unknownFiles);
        }

        private static List<Group> CreateGroups(
            List<FileInfo> fileInfoList,
            GroupType groupType,
            List<GroupType> childGroupTypes)
        {
            var groupList = new List<Group>();

            foreach (var fileInfo in fileInfoList)
            {
                string datePart = GetDatePartByGroupType(fileInfo, groupType);

                //If no suitable group for the item already exists
                if (!groupList.Any(item => item.Name == datePart && item.Type == groupType))
                {
                    var group = new Group(datePart, groupType);

                    //If not at the lowest level of the group tree, create child groups
                    if (childGroupTypes.Count > 1)
                    {
                        // remove the current group from the child groups
                        childGroupTypes.RemoveAt(0);

                        //only select files for the child group which can go in that group
                        var childFileInfoList =
                            fileInfoList.Where(item =>
                            GetDatePartByGroupType(item, groupType) == datePart).ToList();

                        group.ChildGroups =
                            CreateGroups(childFileInfoList, childGroupTypes[0], childGroupTypes);
                    }

                    groupList.Add(group);
                }
            }

            return groupList;
        }

        private static string GetDatePartByGroupType(FileInfo fileInfo, GroupType groupType)
        {
            var dateTime = fileInfo.ItemDate;
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
            using (var streamWriter = new StreamWriter("A:\\debug.json"))
            {
                streamWriter.Write(JsonConvert.SerializeObject(value));
            }
        }
    }
}
