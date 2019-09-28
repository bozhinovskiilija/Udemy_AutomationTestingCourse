using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace TDDPratice
{
    [TestClass]
    [TestCategory("TDDPractice")]
    public class ComplicatedPageTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pathToDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(pathToDriver);
            var complicatedPage = new ComplicatedPage(driver);
            complicatedPage.Open();
            //complicatedPage.SearchAmazon("selenium");
            var amazonPage = complicatedPage.SearchAmazon("selenium");
            Assert.AreEqual("The Latest Changes To Selenium WebDriver 4.0 And How to Fix Your Broken Code [2019]?", amazonPage.ActualSearcResult);
        }
    }
}
