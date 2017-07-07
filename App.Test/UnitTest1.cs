using System;
using Library.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //AppSettings appSettings = new AppSettings();
            //Console.WriteLine($"Environment: {AppSettings.EnvironmentName}");

            //public static string EnvironmentName { get { return AssemblySettings.GetConfig()["envirName"].ToString(); } }
            Console.WriteLine($"Environment: {AssemblySettings.GetConfig()["envirName"].ToString()}");


        }
    }
}
