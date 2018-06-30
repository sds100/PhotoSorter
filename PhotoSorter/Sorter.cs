using Microsoft.WindowsAPICodePack.Shell;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static PhotoSorter.Group;

namespace PhotoSorter
{
    public static class Sorter
    {
        private static readonly string[] MONTHS = new string[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        public static async void SortAsync(string sourceDirectory, string outputDirectory, GroupType[] groupTypes)
        {
            await Task.Run(() =>
            {
                var fileInfoList = new List<FileInfo>();

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
                var groups = CreateGroups(fileInfoList, GroupType.YEAR, groupTypes.ToList());
            });
        }

        private static List<Group> CreateGroups(List<FileInfo> fileInfoList, GroupType groupType, List<GroupType> childGroupTypes)
        {
            var groupList = new List<Group>();

            foreach (var fileInfo in fileInfoList)
            {
                string datePart = GetDatePartByGroupType(fileInfo, groupType);

                if (datePart != null)
                {
                    var groupsWithType = groupList.Where(item => item.Type == groupType);

                    if (!groupsWithType.Any(item => item.Name == datePart))
                    {
                        var group = new Group(datePart, groupType);

                        if (childGroupTypes.Count > 1)
                        {
                            var childFileInfoList = fileInfoList.Where(item => GetDatePartByGroupType(item, groupType) == datePart).ToList();
                            childGroupTypes.RemoveAt(0);

                            group.ChildGroups = CreateGroups(childFileInfoList, childGroupTypes[0], childGroupTypes);
                        }

                        groupList.Add(group);
                    }
                }
            }

            return groupList;
        }

        private static string GetDatePartByGroupType(FileInfo fileInfo, GroupType groupType)
        {
            switch (groupType)
            {
                case GroupType.YEAR:
                    return fileInfo.ItemDate.Year.ToString();

                case GroupType.MONTH:
                    return MONTHS[fileInfo.ItemDate.Month - 1];

                case GroupType.DAY:
                    return fileInfo.ItemDate.Day.ToString();

                default:
                    return null;
            }
        }
    }
}
