using System;
using NLog;
using OpenQA.Selenium;
using SampleApp2.Tests;

namespace SampleApp2.Pages
{
    public class SearchPage : BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public SearchPage(IWebDriver driver): base(driver) { }

        public IWebElement SearchBlouse => Driver.FindElement(By.XPath("//*[@title='Blouse']"));

        public bool Contains(Item searchItem)
        {
            switch (searchItem)
            {
                case Item.Blouse:
                   return SearchBlouse.Displayed;
                default:
                    throw new ArgumentOutOfRangeException("search term not found");
            }
        }
    }
}
