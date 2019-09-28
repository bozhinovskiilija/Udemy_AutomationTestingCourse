using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleApp2.Pages
{
    public class RandomStuffSection:BasePage
    {
        public RandomStuffSection(IWebDriver driver) : base(driver) { }

        public void FillOutForm(string name, string mail, string message)
        {
            Driver.FindElement(By.Id("et_pb_contact_name_0")).SendKeys(name);
            Driver.FindElement(By.Id("et_pb_contact_email_0")).SendKeys(mail);
            Driver.FindElement(By.Id("et_pb_contact_message_0")).SendKeys(message);

            var captchaPuzzle = Driver.FindElements(By.ClassName("et_pb_contact_captcha_question"))[0].Text;
            var split = captchaPuzzle.Split(' ');
            var result = int.Parse(split[0]) + int.Parse(split[2]);

            Driver.FindElements(By.XPath(@"//*[@class='input et_pb_contact_captcha']"))[0].SendKeys(result.ToString());
            Driver.FindElements(By.XPath(@"//*[@class='et_pb_contact_submit et_pb_button']"))[0].Click();

            Reporter.LogPassingTestStepToBugLogger("Fill out the form in the Random Stuff section." + $"Name={name}. Email=>{mail}. Message=>{message}.");
        }

        public bool IsFormSubmitted
        {
            get
            {
                {
                    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                    try
                    {
                        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("et-pb-contact-message")));
                        var isSubmitted = element.Text.Contains("Thanks for contacting us");
                        Reporter.LogTestStepForBugLogger(AventStack.ExtentReports.Status.Pass, "Validate that the form was submitted successfully");
                        return isSubmitted;
                    }
                    catch (WebDriverTimeoutException)
                    {
                        return false;
                    }

                }

            }
        }
    }
}
