// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskCreationNUnitTest.cs" company="">
//   
// </copyright>
// <summary>
//   The task creation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.Operations
{
    #region using directives

    using System;

    using DnsLib.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.FactoryFloor.TodoComponent;

    using NUnit.Framework;

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