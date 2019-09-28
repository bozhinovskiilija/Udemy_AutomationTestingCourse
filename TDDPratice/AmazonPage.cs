using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TDDPratice
{
    public class AmazonPage
    {
        private IWebDriver driver;
        public AmazonPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string ActualSearcResult
        {
            get
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("entry-title")));
                return element.Text;
            }
           
        }
    }
}