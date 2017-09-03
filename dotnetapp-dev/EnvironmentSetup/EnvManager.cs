﻿#region

#endregion

namespace DotnetApp.EnvironmentSetup
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;

    using DotnetApp.AseFramework.Definitions;
    using DotnetApp.Controllers;

    using Xunit.Abstractions;

    #region

    #endregion

    /// <summary>
    ///     The env manager.
    /// </summary>
    public class EnvManager
    {
        /// <summary>
        ///     Gets the ase data d win.
        /// </summary>
        public static string AseDataDWin { get; } =
            Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/data.d";

        /// <summary>
        ///     Gets the env var ase data d.
        /// </summary>
        public static string EnvVarAseDataD { get; } = "ASE_DATA_D";

        /// <summary>
        ///     Gets the flg not available s.
        /// </summary>
        public static string FlgNotAvailableS { get; } = "n/a";

        /// <summary>
        ///     Gets or sets the registry.
        /// </summary>
        private static IDictionary<string, IDictionary<string, object>> Registry { get; set; }

        private static IDictionary<Enum, IDictionary<Enum, List<string>>> EnumRegistry { get; set; }
        public static ITestOutputHelper TestOutputHelper { get; set; }
        public static IWriteLineSupport DefaultOut { get; set; }

        /// <summary>
        ///     The get registry.
        /// </summary>
        /// <returns>
        ///     The
        ///     <see>
        ///         <cref>IDictionary</cref>
        ///     </see>
        ///     .
        /// </returns>
        [SuppressMessage(
            "StyleCop.CSharp.OrderingRules",
            "SA1216:NoValueFirstComparison",
            Justification = "Reviewed. Suppression is OK here.")]
        public static IDictionary<string, IDictionary<string, object>> GetRegistry()
        {
            if (null == Registry)
            {
                SetRegistry(new Dictionary<string, IDictionary<string, object>>());

                var registryRegistry = new Dictionary<string, object> {["/0/tags/registry-create-ts"] = DateTime.Now};
                Debug.Assert(Registry != null, nameof(Registry) + " != null");
                Registry["/root/rel/registry"] = registryRegistry;
            }

            return Registry;
        }

        public static IDictionary<Enum, IDictionary<Enum, List<string>>> GetEnumRegistry()
        {
            if (null == EnumRegistry)
            {
                SetEnumRegistry(new Dictionary<Enum, IDictionary<Enum, List<string>>>());
                var enumRegistry = new Dictionary<Enum, List<string>>
                {
                    [EnumRegistryKeys.Base] = new List<string> {DateTimeOffset.Now.ToString()}
                };
                Debug.Assert(EnumRegistry != null, nameof(EnumRegistry) + " != null");
                EnumRegistry[EnumRegistryKeys.Self] = enumRegistry;
            }
            return EnumRegistry;
        }

        /// <summary>
        ///     The set registry.
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        public static void SetRegistry(IDictionary<string, IDictionary<string, object>> value)
        {
            Registry = value;
        }

        public static void SetEnumRegistry(IDictionary<Enum, IDictionary<Enum, List<string>>> value)
        {
            EnumRegistry = value;
        }

        /// <summary>
        ///     The init testing registry.
        /// </summary>
        public static void InitTestingRegistry()
        {
            var registry = GetRegistry();
            registry["/root/rel/view/testing"] =
                new SortedDictionary<string, object> {["/0/tags/registry-create-ts"] = DateTime.Now};
        }

        public static void NewLine()
        {
            Console.Out.Write(Environment.NewLine);
        }

        public static void WriteLine(string s)
        {
            if (null != DefaultOut) DefaultOut.WriteLine(s);
            else Console.Out.WriteLine(s);
        }

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
                var s = Environment.GetEnvironmentVariable(EnvVarAseDataD);
                if (null == s)
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

                    s = AseDataDWin;
                    Environment.SetEnvironmentVariable(EnvVarAseDataD, s);
                }

                Debug.WriteLine($"ASE_DATA_D env var set to {s}");
                return s;
            }
        }
    }
}