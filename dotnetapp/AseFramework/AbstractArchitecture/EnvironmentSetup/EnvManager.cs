#region using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using DotnetApp.AseFramework.AbstractArchitecture.Definitions;
using Xunit.Abstractions;

#endregion

namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    #region using directives

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
        ///     Gets or sets the default out.
        /// </summary>
        public static IWriteLineSupport DefaultOut { get; set; }

        /// <summary>
        ///     Gets the env var ase data d.
        /// </summary>
        public static string EnvVarAseDataD { get; } = "ASE_DATA_D";

        /// <summary>
        ///     Gets the flg not available s.
        /// </summary>
        public static string FlgNotAvailableS { get; } = "n/a";

        /// <summary>
        ///     Gets or sets the test output helper.
        /// </summary>
        public static ITestOutputHelper TestOutputHelper { get; set; }

        /// <summary>
        ///     Gets or sets the enum registry.
        /// </summary>
        private static IDictionary<Enum, IDictionary<Enum, List<string>>> EnumRegistry { get; set; }

        /// <summary>
        ///     Gets or sets the registry.
        /// </summary>
        private static IDictionary<string, IDictionary<string, object>> Registry { get; set; }

        /// <summary>
        ///     The get enum registry.
        /// </summary>
        /// <returns>
        ///     The <see>
        ///         <cref>IDictionary</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static IDictionary<Enum, IDictionary<Enum, List<string>>> GetEnumRegistry()
        {
            switch (EnumRegistry)
            {
                case null:
                    SetEnumRegistry(new Dictionary<Enum, IDictionary<Enum, List<string>>>());
                    var enumRegistry =
                        new Dictionary<Enum, List<string>>
                        {
                            [EnumRegistryKeys.Base] =
                            new List<string> {DateTimeOffset.Now.ToString()}
                        };
                    Debug.Assert(EnumRegistry != null, nameof(EnumRegistry) + " != null");
                    EnumRegistry[EnumRegistryKeys.Self] = enumRegistry;
                    break;
            }

            return EnumRegistry;
        }

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
            switch (Registry)
            {
                case null:
                    SetRegistry(new Dictionary<string, IDictionary<string, object>>());

                    var registryRegistry =
                        new Dictionary<string, object> {["/0/tags/registry-create-ts"] = DateTime.Now};
                    Debug.Assert(Registry != null, nameof(Registry) + " != null");
                    Registry["/root/rel/registry"] = registryRegistry;
                    break;
            }

            return Registry;
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

        /// <summary>
        ///     The new line.
        /// </summary>
        public static void NewLine()
        {
            WriteLine();
        }

        /// <summary>
        ///     The set enum registry.
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        public static void SetEnumRegistry(IDictionary<Enum, IDictionary<Enum, List<string>>> value)
        {
            EnumRegistry = value;
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

        /// <summary>
        ///     The write line.
        /// </summary>
        /// <param name="s">
        ///     The s.
        /// </param>
        /// <param name="category"></param>
        public static void WriteLine(string s = null, string category = "")
        {
            s = s ?? Environment.NewLine;
            s += category.Trim().Length == 0 ? string.Empty : $", {category}";
            if (TestOutputHelper != null) TestOutputHelper.WriteLine(s);
            else if (DefaultOut != null) DefaultOut.WriteLine(s);
            else Console.Out.WriteLine(s);
        }
    }
}