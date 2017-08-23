// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="ase">
//   mit
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotNetApp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    ///     The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     The get bot.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public static string GetBot(string message)
        {
            var bot = GetBotHeader(message);
            bot += @"
    __________________
                      \
                       \
                          ....
                          ....'
                           ....
                        ..........
                    .............'..'..
                 ................'..'.....
               .......'..........'..'..'....
              ........'..........'..'..'.....
             .'....'..'..........'..'.......'.
             .'..................'...   ......
             .  ......'.........         .....
             .                           ......
            ..    .            ..        ......
           ....       .                 .......
           ......  .......          ............
            ................  ......................
            ........................'................
           ......................'..'......    .......
        .........................'..'.....       .......
     ........    ..'.............'..'....      ..........
   ..'..'...      ...............'.......      ..........
  ...'......     ...... ..........  ......         .......
 ...........   .......              ........        ......
.......        '...'.'.              '.'.'.'         ....
.......       .....'..               ..'.....
   ..       ..........               ..'........
          ............               ..............
         .............               '..............
        ...........'..              .'.'............
       ...............              .'.'.............
      .............'..               ..'..'...........
      ...............                 .'..............
       .........                        ..............
        .....

";
            return bot;
        }

        /// <summary>
        ///     The main.
        /// </summary>
        /// <param name="args">
        ///     The args.
        /// </param>
        public static void Main(string[] args)
        {
            var message = BuildMessage(args);

            // setup environmentDict
            IDictionary<string, string> environmentDict = EnvironmentDict();

            WriteLine(GetBot(message));
            WriteEnvironmentDescription(environmentDict);
        }

        /// <summary>
        ///     The build message.
        /// </summary>
        /// <param name="args">
        ///     The args.
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private static string BuildMessage(string[] args)
        {
            // data
            var message = "Dotnet-bot: Welcome to using .NET Core!";

            if (args.Length > 0)
            {
                message = string.Join(" ", args);
            }

            return message;
        }

        /// <summary>
        ///     The environment dict.
        /// </summary>
        /// <returns>
        ///     The <see cref="IDictionary{TKey,TValue}" />.
        /// </returns>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private static Dictionary<string, string> EnvironmentDict()
        {
            return new Dictionary<string, string>
                       {
                           ["DEBUG"] = GetEnvironmentVariableWithOptions("DEBUG", "OFF"),
                           ["eins"] = GetEnvironmentVariableWithOptions("eins", "1"),
                           ["zwo"] = GetEnvironmentVariableWithOptions("zwo", "2")
                       };
        }

        /// <summary>
        ///     The get bot header.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private static string GetBotHeader(string message)
        {
            var bot = $"\n        {message}";
            bot += Environment.NewLine;
            bot += Environment.NewLine;
            return bot;
        }

        /// <summary>
        ///     The get environment variable with options.
        /// </summary>
        /// <param name="variable">
        ///     The variable.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private static string GetEnvironmentVariableWithOptions(string variable, string defaultValue)
        {
            var flgDebug = Environment.GetEnvironmentVariable(variable) ?? defaultValue;
            flgDebug = string.Empty == flgDebug ? defaultValue : flgDebug;
            return flgDebug;
        }

        /// <summary>
        ///     The write environment description.
        /// </summary>
        /// <param name="environmentDict">
        ///     The environment dict.
        /// </param>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private static void WriteEnvironmentDescription(IDictionary<string, string> environmentDict)
        {
            WriteLine("**Environment**");
            WriteLine($"Platform: .NET Core 2.0");
            WriteLine($"OS: {RuntimeInformation.OSDescription}");
            WriteLine();
            WriteLine(
                $"Flags: " + Environment.NewLine + $"\t flgDebug  : \t {environmentDict["DEBUG"]}" + Environment.NewLine
                + $"\t flgEins   : \t {environmentDict["eins"]}" + Environment.NewLine
                + $"\t flgZwo    : \t {environmentDict["zwo"]}");
        }

        /// <summary>
        ///     The write line.
        /// </summary>
        /// <param name="s">
        ///     The s.
        /// </param>
        [SuppressMessage(
            "StyleCop.CSharp.LayoutRules",
            "SA1503:CurlyBracketsMustNotBeOmitted",
            Justification = "Reviewed. Suppression is OK here.")]
        private static void WriteLine(string s = null)
        {
            if (string.Equals(null, s, StringComparison.Ordinal)) s = Environment.NewLine;
            Debug.WriteLine(string.Format("s = {0}", s));
            Console.Out.WriteLine("s = {0}", s);
        }
    }
}