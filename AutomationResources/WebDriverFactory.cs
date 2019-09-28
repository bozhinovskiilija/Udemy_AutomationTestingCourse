using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver Driver;

        public IWebDriver Create(Browser browserType)
        {
            switch (browserType)
            {
                case Browser.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("no such browser exists");
            }
        }

        private IWebDriver GetChromeDriver()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(path);
        }
    }
}
