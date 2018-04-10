using System;
using DnsLib.FactoryFloor.Lab;
using DnsLib.FactoryFloor.TodoComponent;
using DnsLib.SysRes;
using NUnit.Framework;

namespace DotnetApp.CustomSetup
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

            PlatformSysGen.EnvironmentManager.DefaultOut = new EnvironmentOutputAdapter(Console.Out);
            PlatformSysGen.EnvironmentManager.WriteLine($"extraCreatorInfo: {item.ExtraCreatorInfo}");

            Assert.IsNotNull(item.CreatedAt);
        }
    }
}