#region using directives

using System;

#endregion

namespace DotnetApp.AseFramework.AbstractArchitecture.Definitions
{
    #region using directives

    #endregion

    /// <summary>
    ///     The ase message event args.
    /// </summary>
    public class AseMessageEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AseMessageEventArgs" /> class.
        /// </summary>
        /// <param name="s">
        ///     The s.
        /// </param>
        public AseMessageEventArgs(string s)
        {
            Message = s;
        }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        public string Message { get; }
    }
}