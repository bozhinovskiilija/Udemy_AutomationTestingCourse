using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SampleFramework1
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }

        public BasePage (IWebDriver driver)
        {
            Driver = driver;
        }

            
    }
}
