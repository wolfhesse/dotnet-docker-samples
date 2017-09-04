#region using directives

using System;

#endregion

namespace DotnetApp.AseFramework.Models
{
    #region using directives

    #endregion

    /// <summary>
    ///     The interop types.
    /// </summary>
    public static class InteropTypes
    {
        /// <summary>
        ///     The v 1.
        /// </summary>
        public class V1
        {
            /// <summary>
            ///     The tweet model.
            /// </summary>
            public class TweetModel
            {
                // public string _id { get; set; }
                // public int? Id { get; set; }
                /// <summary>
                ///     Gets or sets the id.
                /// </summary>
                public string Id { get; set; }

                /// <summary>
                ///     Gets or sets the post date time.
                /// </summary>
                public DateTime PostDateTime { get; set; }

                /// <summary>
                ///     Gets or sets the user.
                /// </summary>
                public string User { get; set; }

                /// <summary>
                ///     Gets or sets the value.
                /// </summary>
                public string Value { get; set; }

                /// <summary>
                ///     Gets the version.
                /// </summary>
                public string Version { get; } = typeof(TweetModel).AssemblyQualifiedName;

                /// <summary>
                ///     The to string.
                /// </summary>
                /// <returns>
                ///     The <see cref="string" />.
                /// </returns>
                public override string ToString()
                {
                    var res = base.ToString();

                    // res += $"\n \\.. _id          : {_id}";
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