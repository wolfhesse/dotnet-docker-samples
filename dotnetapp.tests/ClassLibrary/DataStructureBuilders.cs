using System;
using DnsLib.EnvironmentSetup;
using DnsLib.TodoComponent;
using NUnit.Framework;

namespace DotnetApp.Tests.ClassLibrary
{
    #region using directives

    #endregion

    /// <summary>
    ///     The task creation.
    /// </summary>
    [TestFixture]
    public class DataStructureBuilders
    {
        /// <summary>
        ///     The test task created at.
        /// </summary>
        [Test]
        public void TestTodoBuilder()
        {
            var item = TodoBuilder.BuildTodo("sample");

            EnvManager.DefaultOut = new EnvironmentOutputAdapter(Console.Out);
            EnvManager.WriteLine($"extraCreatorInfo: {item.ExtraCreatorInfo}");

            Assert.IsNotNull(item.CreatedAt);
        }
    }
}