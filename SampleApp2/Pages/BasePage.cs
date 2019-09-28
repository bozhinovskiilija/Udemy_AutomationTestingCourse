using OpenQA.Selenium;

namespace SampleApp2.Pages
{
   public class BasePage
    {
        public IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
