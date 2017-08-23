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
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    ///     The program.
    /// </summary>
    public static class Program
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
            var bot = $"\n        {message}";
            bot += Environment.NewLine;
            bot += "line";
            bot += Environment.NewLine;
            bot += "line";
            bot += Environment.NewLine;
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
            // setup environmentDict
            var flgDebug = Environment.GetEnvironmentVariable("DEBUG");

            if (flgDebug == null)
            {
                flgDebug = "OFF";
            }

            if (string.Empty == flgDebug.ToString())
            {
                flgDebug = "OFF";
            }

            IDictionary<string, string> environmentDict = new Dictionary<string, string>() { ["DEBUG"] = flgDebug };
            
            // data
            var message = "Dotnet-bot: Welcome to using .NET Core!";

            if (args.Length > 0) message = string.Join(" ", args);

            WriteLine(GetBot(message));
            WriteLine("**Environment**");
            WriteLine($"Platform: .NET Core 2.0");
            WriteLine($"OS: {RuntimeInformation.OSDescription}");
            WriteLine();
            WriteLine($"Flags: flgDebug: {environmentDict["DEBUG"]}");
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