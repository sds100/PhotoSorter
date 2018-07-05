using System;
using System.Collections.Generic;

namespace PhotoSorter
{
    /// <summary>
    /// Represents a folder in the sort tree. E.g /2017 or /2017/March
    /// </summary>
    public struct Group : IComparable
    {
        public static List<KeyValuePair<string, string>> GroupTypeTitles
            = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(GroupName.YEAR_FORMAT, "Year"),
                new KeyValuePair<string, string>(GroupName.MONTH_FORMAT, "Month"),
                new KeyValuePair<string, string>(GroupName.DAY_FORMAT, "Day"),
                new KeyValuePair<string, string>(GroupName.HOUR_FORMAT, "Hour")
            };

        public GroupName Name { get; }

        public List<Group> ChildrenGroups { get; set; }
        public List<PhotoInfo> Files { get; set; }

        public bool HasFiles => Files.Count > 0;
        public bool HasChildrenGroups => ChildrenGroups.Count > 0;

        public Group(GroupName groupName)
        {
            Name = groupName;

            ChildrenGroups = new List<Group>();
            Files = new List<PhotoInfo>();
        }

        public int CompareTo(object obj)
        {
            var group2 = (Group)obj;
            return this.Name.CompareTo(group2.Name);
        }
    }
}
