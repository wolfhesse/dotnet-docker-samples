// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinitionZulu.cs" company="">
//   
// </copyright>
// <summary>
//   The definition zulu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.AseFramework.Definitions
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The definition zulu.
    /// </summary>
    public class DefinitionZulu
    {
        /// <summary>
        ///     The data d.
        /// </summary>
        public static string DataD => Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/data.d";

        /// <summary>
        ///     The trace.
        /// </summary>
        public static string Trace => typeof(DefinitionZulu).AssemblyQualifiedName;
    }
}