using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SampleApp2.Pages
{
   public class ComplicatedPage : BasePage
    {
        public RandomStuffSection RandonStuffSection { get; set; }

        public ComplicatedPage(IWebDriver driver) : base(driver)
        {
            RandonStuffSection = new RandomStuffSection(driver);
        }

        public void GoTo()
        {
            string url = "https://www.ultimateqa.com/complicated-page/";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogTestStepForBugLogger(Status.Info, $"Navigate to Complicated page url {url}");
        }

        public bool isLoaded
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Validate that Sign in page loaded successfully.");

                    return Driver.Url.Contains("complicated-page");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
}
