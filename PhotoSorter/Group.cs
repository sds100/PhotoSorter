using System.Collections.Generic;

namespace PhotoSorter
{
    /// <summary>
    /// Represents a folder in the sort tree. E.g /2017 or /2017/March
    /// </summary>
    public struct Group
    {
        public string Name { get; }
        public GroupType Type { get; }
        public List<Group> ChildGroups { get; set; }
        public List<PhotoInfo> Files { get; }

        public Group(string name, GroupType type)
        {
            Name = name;
            Type = type;
            ChildGroups = new List<Group>();
            Files = new List<PhotoInfo>();
        }

        public enum GroupType
        {
            YEAR, MONTH, DAY         
            // Hour, minute???
        }
    }
}
