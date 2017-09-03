using System;

namespace ClassLibrary.AseFramework.Models
{
    public static class InteropTypes
    {
        public class V1
        {
            public class Tweet
            {
//                public string _id { get; set; }
//                public int? Id { get; set; }
                public string Id { get; set; }
                public string User { get; set; }
                public DateTime PostDateTime { get; set; }
                public string Value { get; set; }
                public string Version { get; } = typeof(Tweet).AssemblyQualifiedName;

                public override string ToString()
                {
                    var res = base.ToString();
//                    res += $"\n \\.. _id          : {_id}";
                    res += $"\n \\.. id           : {Id}";
                    res += $"\n \\.. user         : {User}";
                    res += $"\n \\.. postDateTime : {PostDateTime}";
                    res += $"\n \\.. value        : {Value}";
                    res += $"\n \\.. version        : {Version}";
                    res += $"\n \\.. ]";
                    return res;
                }
            }
        }
    }
}