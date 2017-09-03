// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AseMessageEventArgs.cs" company="">
//   
// </copyright>
// <summary>
//   The ase message event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.AseFramework.Definitions
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The ase message event args.
    /// </summary>
    public class AseMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AseMessageEventArgs"/> class.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        public AseMessageEventArgs(string s)
        {
            this.Message = s;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; }
    }
}