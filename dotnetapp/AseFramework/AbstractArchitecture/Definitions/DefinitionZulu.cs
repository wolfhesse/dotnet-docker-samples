namespace DotnetApp.AseFramework.AbstractArchitecture.Definitions
{
    #region using directives

    using System;

    #endregion

    /// <summary>
    ///     The definition zulu.
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