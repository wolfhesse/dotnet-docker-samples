namespace DotnetApp.AseFramework.Models
{
    #region using directives

    using System;

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