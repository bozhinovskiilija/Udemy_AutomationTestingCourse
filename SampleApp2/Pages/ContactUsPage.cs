using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SampleApp2.Pages
{
    public class ContactUsPage : BasePage
    {
        public ContactUsPage(IWebDriver driver) : base(driver){}

        public bool IsLoaded
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Validate that Contact Us page loaded successfully.");

                    return Driver.FindElement(By.CssSelector(".page-heading.bottom-indent")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
                       
        public void GoTo()
        {
            var url = "http://automationpractice.com/index.php?controller=contact";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for Contact Us page.");
        }
    }
}