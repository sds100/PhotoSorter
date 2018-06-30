using System.Collections.Generic;

namespace PhotoSorter
{
    public struct Group
    {
        public string Name { get; }
        public GroupType Type { get; }
        public List<Group> ChildGroups { get; set; }
        public List<FileInfo> Files { get; }

        public Group(string name, GroupType type)
        {
            Name = name;
            Type = type;
            ChildGroups = new List<Group>();
            Files = new List<FileInfo>();
        }

        public enum GroupType
        {
            YEAR, MONTH, DAY         
            // Hour, minute???
        }
    }
}
