using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("Regression")]
    public class SampleApplicationOneTests
    {
        public IWebDriver Driver  { get; set; }
        public SampleApplicationPage sampleApp { get; set; }
        public User TestUser { get; set; }
        public User EmergencyTestUser { get; set; }


        [TestInitialize]
        public void SetupForEverySingleMethod()
        {
            Driver = GetChromeDriver();
            Driver.Manage().Window.Maximize();

            sampleApp = new SampleApplicationPage(Driver);

            TestUser = new User();
            TestUser.Firstname = "Pero";
            TestUser.Lastname = "Perovski";
//            TestUser.GenderType = Gender.Female;
            EmergencyTestUser=new User();
            EmergencyTestUser.Firstname = "mitre";
            EmergencyTestUser.Lastname = "mitrovski";
            EmergencyTestUser.GenderType = Gender.Other;
        }

        [TestCleanup]
        public void CleanUpAfterEveryMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

       
        [TestMethod]
        [Description("Testing the fill out form")]
        public void TC1()
        {
            sampleApp.GoTo();
            Assert.IsTrue(sampleApp.IsVisible);

            TestUser.GenderType = Gender.Female;
            sampleApp.FillOutEmergencyForm(EmergencyTestUser);
            var ultimateQaHomePage = sampleApp.FillOutFormAndSubmit(TestUser);

            Thread.Sleep(3000);

            Assert.IsTrue(ultimateQaHomePage.IsVisible,"ultimateqahome page was not visibe");           
        }

        [TestMethod]
        [Description("Pretending test case 2")]
        public void TC2() //PBI(ProductBacklogItem  ex. PBI-INPIS_253)
        {
            sampleApp.GoTo();
            Assert.IsTrue(sampleApp.IsVisible);

            TestUser.GenderType = Gender.Other;

            var ultimateQaHomePage = sampleApp.FillOutFormAndSubmit(TestUser);
            Thread.Sleep(3000);
            Assert.IsTrue(ultimateQaHomePage.IsVisible, "ultimateqahome page was not visibe");
        }

        private IWebDriver GetChromeDriver()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(path);
        }
    }
}
