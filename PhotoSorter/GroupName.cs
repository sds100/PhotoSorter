using System;
using System.Collections.Generic;

namespace PhotoSorter
{
    /// <summary>
    /// Represents the name of a group. Which is a part of the date (e.g 2017) and the
    /// format it is in. (E.g YYYY)
    /// </summary>
    public class GroupName : IComparable
    {
        public const string YEAR_FORMAT = "yyyy";
        public const string MONTH_FORMAT = "MMMM";
        public const string DAY_FORMAT = "MMMM-dd";
        public const string HOUR_FORMAT = "HH";

        private string Name { get; }
        private DateTime Date { get; }
        private string Format { get; }

        public GroupName(DateTime date, string format)
        {
            Name = date.ToString(format);
            Date = date;
        }

        public int CompareTo(object obj)
        {
            var groupName2 = (GroupName)obj;

            return this.Date.CompareTo(groupName2.Date);
        }

        public static bool operator ==(GroupName name1, GroupName name2) => name1.Equals(name2);

        public static bool operator !=(GroupName name1, GroupName name2) => !name1.Equals(name2);

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            return this.ToString() == ((GroupName)obj).ToString();
        }

        public override int GetHashCode()
        {
            var hashCode = 533883240;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Format);
            return hashCode;
        }
    }
}
