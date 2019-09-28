using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SampleApp2.Pages
{
    public class Header : BasePage
    {
        public Header(IWebDriver driver) : base(driver) { }

        public IWebElement ContactUsButton => Driver.FindElement(By.Id("contact-link"));
        public IWebElement SignInButton => Driver.FindElement(By.ClassName("login"));
        public ContactUsPage ClickContactUsButton()
        {
           ContactUsButton.Click();
           Reporter.LogPassingTestStepToBugLogger("Click the contact us button in the header");
           return new ContactUsPage(Driver);
        }

        public SignInPage ClickSignInButton()
        {
            SignInButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the sign in button in the header");
            return new SignInPage(Driver);

        }
    }
}
