// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgramSample.cs" company="">
//   
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib.EnvironmentSetup;
using DnsLib.FactoryFloor.Lab;
using DnsLib.TodoComponent;

namespace DotnetApp.Tests.ClassLibrary
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

   

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    ///     The program.
    /// </summary>
    public class ProgramSample
    {
        /// <summary>
        ///     The serialized environment.
        /// </summary>
        private static string serializedEnvironment;

        /// <summary>The configure task repository event handler.</summary>
        /// <param name="InMemoryTodoRepositoryOnEvTaskAdded">The in memory task repository on ev task added.</param>
        public static void ConfigureTaskRepositoryEventHandler(
            AbstractTodoRepository.TodoAddedEventHandler InMemoryTodoRepositoryOnEvTaskAdded)
        {
            InMemoryTodoEngine.Init();

            // todo move EvTaskAdded to Engine
            TodoController.TodoRepository.EvTodoAdded += InMemoryTodoRepositoryOnEvTaskAdded;
        }

        /// <summary>The main.</summary>
        /// <param name="args">The args.</param>
        public static void Entrypoint(string[] args)
        {
            ConfigureTaskRepositoryEventHandler(
                delegate(object sender, TodoEventArgs eventArgs)
                    {
                        EnvManager.WriteLine(
                            $"oh: task created{Environment.NewLine} at {DateTimeOffset.Now}{Environment.NewLine} by {sender}{Environment.NewLine} with args {args}");
                        Console.Out.WriteLine("con: task created");
                    });
            var message = BuildMessage(args);

            // setup environmentDict
            IDictionary<string, string> environmentDict = EnvironmentDict();

            WriteLineWithSignifier(GetBot(message));
            WriteEnvironmentDescription(environmentDict);

            EnvManager.WriteLine(PreparedSerializedEnvironmentSingleLine());
            TaskBuilderAddSet();
            TaskBuilderAddSet();
            TaskBuilderAddSet();
            TaskBuilderAddSet();
            TaskBuilderAddSet();
            var taskRepositoryCount = TodoController.TodoRepository.Count;
            Console.Out.WriteLine("taskRepositoryCount = {0}", taskRepositoryCount);
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
        public static Dictionary<string, string> EnvironmentDict()
        {
            return new Dictionary<string, string>
                       {
                           ["DEBUG"] = GetEnvironmentVariableWithOptions("DEBUG", "OFF"),
                           ["eins"] = GetEnvironmentVariableWithOptions("eins", "1"),
                           ["zwo"] = GetEnvironmentVariableWithOptions("zwo", "2")
                       };
        }

        /// <summary>The get bot.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="string"/>.</returns>
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


---
x-ase-sect-PAT_ANF
acht
x-ase-sect-PAT_END
---
";
            return bot;
        }

        /// <summary>
        ///     The r write serialized env.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public static string PreparedSerializedEnvironmentSingleLine()
        {
            var env = EnvironmentDict();
            env.Add("TS_NOW", DateTimeOffset.Now.ToString());
            env.Add("PAT_RECORD", ".here");

            serializedEnvironment = JsonConvert.SerializeObject(env, Formatting.None);
            return serializedEnvironment;
        }

        /// <summary>The build message.</summary>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string BuildMessage(string[] args)
        {
            // data
            var message = "Dotnet-bot: Welcome to using .NET Core!";

            if (args != null && args.Length > 0) message = string.Join(" ", args);

            return message;
        }

        /// <summary>The get bot header.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetBotHeader(string message)
        {
            var bot = $"\n        {message}";
            bot += Environment.NewLine;
            bot += Environment.NewLine;
            return bot;
        }

        /// <summary>The get environment variable with options.</summary>
        /// <param name="variable">The variable.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetEnvironmentVariableWithOptions(string variable, string defaultValue)
        {
            var flgDebug = Environment.GetEnvironmentVariable(variable) ?? defaultValue;
            flgDebug = string.Empty == flgDebug ? defaultValue : flgDebug;
            return flgDebug;
        }

        /// <summary>The task builder add set.</summary>
        private static void TaskBuilderAddSet()
        {
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).ToString());
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).ToString());
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
            TodoController.AddTodo(TodoBuilder.BuildTodo("1eins" + DateTimeOffset.Now.UtcTicks).Title);
        }

        /// <summary>The write environment description.</summary>
        /// <param name="environmentDict">The environment dict.</param>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private static void WriteEnvironmentDescription(IDictionary<string, string> environmentDict)
        {
            WriteLineWithSignifier("**Environment**");
            WriteLineWithSignifier($"Platform: .NET Core 2.0");
            WriteLineWithSignifier($"OS: {RuntimeInformation.OSDescription}");
            WriteLineWithSignifier();
            WriteLineWithSignifier(
                $"Flags: " + Environment.NewLine + $"\t flgDebug  : \t {environmentDict["DEBUG"]}" + Environment.NewLine
                + $"\t flgEins   : \t {environmentDict["eins"]}" + Environment.NewLine
                + $"\t flgZwo    : \t {environmentDict["zwo"]}");
        }

        /// <summary>The write line.</summary>
        /// <param name="s">The s.</param>
        [SuppressMessage(
            "StyleCop.CSharp.LayoutRules",
            "SA1503:CurlyBracketsMustNotBeOmitted",
            Justification = "Reviewed. Suppression is OK here.")]
        private static void WriteLineWithSignifier(string s = null)
        {
            if (string.Equals(null, s, StringComparison.Ordinal)) s = Environment.NewLine;
            EnvManager.WriteLine(string.Format("s = {0}", s));
            Console.Out.WriteLine("s = {0}", s);
        }
    }
}