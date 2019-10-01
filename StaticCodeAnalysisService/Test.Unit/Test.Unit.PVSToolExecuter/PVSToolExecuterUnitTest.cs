﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Unit.PVSToolExecuter
{
    [TestClass]
    public class PVSToolExecuterUnitTest
    {
        Contracts.ToolExecuter.IToolExecuter toolExecuter;

        [TestInitialize]
        public void TestInitialize()
        {
            toolExecuter = new PVS.ToolExecuterLib.PVSToolExecuter();
        }

        [TestCleanup]
        public void DeleteTestFolder()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\StaticAnalysisData\BatchFiles\DeleteTestResult.bat";
            proc.Start();
            proc.WaitForExit();
        }

        [TestMethod]
        public void Given_Valid_Arguments_When_ExecuteTool_Invoked_Then_true_Asserted()
        {
            string path = @"C:\StaticAnalysisData\TestFiles";
            Assert.IsTrue(toolExecuter.ExecuteTool("Admin", path));

           
        }

        [TestMethod]
        public void Given_InValid_Arguments_When_ExecuteTool_Invoked_Then_true_Asserted()
        {
            string path = "InvallidPath";
            Assert.IsFalse(toolExecuter.ExecuteTool("Admin", path));
        }
    }
}
