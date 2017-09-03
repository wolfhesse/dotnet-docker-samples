#region

#endregion

namespace DotnetApp.AseFramework.Definitions
{
    using System;

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