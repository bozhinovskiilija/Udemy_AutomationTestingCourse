using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SampleApp2.Pages
{
    public class SignInPage:BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver) { }

        //class -> page-heading

        public IWebElement PageHeader => Driver.FindElement(By.ClassName("page-heading"));

        public bool isLoaded
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Validate that Sign in page loaded successfully.");

                    return PageHeader.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        }

    }

