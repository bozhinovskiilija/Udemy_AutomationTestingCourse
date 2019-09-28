using System;
using OpenQA.Selenium;

namespace SampleFramework1
{
    public class UltimateQaHomePage: BasePage
    {
        public UltimateQaHomePage(IWebDriver driver):base(driver) {}

        public  IWebElement HomePageMainHeader => Driver.FindElement(By.XPath("//*[contains(text(),'Learn Critical Automation and Dev Skills')]"));

        public bool IsVisible
        {
            get
            {
                try
                {
                   return HomePageMainHeader.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }


        



    }
}