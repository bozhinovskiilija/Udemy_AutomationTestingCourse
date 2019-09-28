using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TDDPratice
{
    public class ComplicatedPage
    {
        public IWebDriver Driver { get; set; }

        public ComplicatedPage(IWebDriver driver)
        {
            Driver = driver;
        }     

        public void Open()
        {
           Driver.Navigate().GoToUrl("https://www.ultimateqa.com/complicated-page/");
        }

        public AmazonPage SearchAmazon(string term)
        {
           Driver.FindElements(By.Id("s"))[0].SendKeys(term);
           Driver.FindElements(By.Id("searchsubmit"))[0].Submit();

          // Driver.SwitchTo().Window(Driver.WindowHandles[1]); if the new page is open in new window(new browser is open)

           return new AmazonPage(Driver);
        }
    }
}