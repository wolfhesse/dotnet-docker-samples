#region

#endregion

namespace DotnetApp.AseFramework.Models
{
    using System;

    public static class InteropTypes
    {
        public class V1
        {
            public class TweetModel
            {
//                public string _id { get; set; }
//                public int? Id { get; set; }
                public string Id { get; set; }

                public string User { get; set; }
                public DateTime PostDateTime { get; set; }
                public string Value { get; set; }
                public string Version { get; } = typeof(TweetModel).AssemblyQualifiedName;

                public override string ToString()
                {
                    var res = base.ToString();
//                    res += $"\n \\.. _id          : {_id}";
                    res += $"\n \\.. id           : {this.Id}";
                    res += $"\n \\.. user         : {this.User}";
                    res += $"\n \\.. postDateTime : {this.PostDateTime}";
                    res += $"\n \\.. value        : {this.Value}";
                    res += $"\n \\.. version        : {this.Version}";
                    res += $"\n \\.. ]";
                    return res;
                }
            }
        }
    }
}