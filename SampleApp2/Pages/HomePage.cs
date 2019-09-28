using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;

namespace SampleApp2.Pages
{
    public class HomePage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public Slider Slider { get; set; }
        public Header Header { get; set; }

        public HomePage(IWebDriver driver):base(driver)
        {
            Slider=new Slider(driver);
            Header=new Header(driver);
        }

        public void GoTo()
        {
            var url = "http://automationpractice.com/index.php";
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Reporter.LogPassingTestStepToBugLogger($"In a browser, go to url=>{url}");
            _logger.Info($"Opened url => {url}");
        }

        public bool IsLoaded
        {

            get
            {
                var isLoaded = Driver.Url.Contains("http://automationpractice.com/index.php");
                Reporter.LogTestStepForBugLogger(Status.Info, "Validate whether the Home Page loaded successfully.");
                _logger.Trace($"Home page is loaded=>{isLoaded}");
                return isLoaded;
            }
        }

        public SearchPage Search(string searchTerm)
        {
            _logger.Trace("Attempting to perform a search");

            Driver.FindElement(By.Id("search_query_top")).SendKeys(searchTerm);
            Driver.FindElement(By.Name("submit_search")).Click();

            _logger.Info($"Search for an item in the search bar => {searchTerm}");

            Reporter.LogTestStepForBugLogger(Status.Info,$"Search for=>{searchTerm} in the search bar on the page.");

            return new SearchPage(Driver);
        }


    }
}
