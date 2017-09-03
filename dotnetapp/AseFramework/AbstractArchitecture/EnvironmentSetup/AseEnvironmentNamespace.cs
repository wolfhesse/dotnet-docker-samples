// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AseEnvironmentNamespace.cs" company="">
//   
// </copyright>
// <summary>
//   The ase environment namespace.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    #region using directives

    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;

    using DotnetApp.AseFramework.Controllers;

    #endregion

    /// <summary>
    ///     The ase environment namespace.
    /// </summary>
    public class AseEnvironmentNamespace
    {
        /// <summary>
        ///     The get data d.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        [SuppressMessage(
            "StyleCop.CSharp.OrderingRules",
            "SA1216:NoValueFirstComparison",
            Justification = "Reviewed. Suppression is OK here.")]
        public static string GetDataD()
        {
            var s = Environment.GetEnvironmentVariable(EnvManager.EnvVarAseDataD);
            if (s == null)
            {
                // bail out
                var sw = new StringWriter(new StringBuilder());
                try
                {
                    GeneralOperations.err_handling_bail_out(sw, "get env var ASE_DATA_D");
                }
                catch (Exception e)
                {
                    sw.WriteLine($"exception: {e.Message}");
                }

                Debug.WriteLine(sw.ToString());

                s = EnvManager.AseDataDWin;
                Environment.SetEnvironmentVariable(EnvManager.EnvVarAseDataD, s);
            }

            Debug.WriteLine($"ASE_DATA_D env var set to {s}");
            return s;
        }
    }
}