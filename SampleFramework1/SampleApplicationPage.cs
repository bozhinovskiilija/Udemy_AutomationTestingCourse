using System;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleFramework1
{
    public class SampleApplicationPage : BasePage
    {

        public SampleApplicationPage(IWebDriver driver) : base(driver){}


        public IWebElement FemaleRadioButtonEmergency => Driver.FindElement(By.Id("radio2-f"));
        public IWebElement OtherRadioButtonEmergency => Driver.FindElement(By.Id("radio1-0"));

        public IWebElement FirstNameFieldEmergancy => Driver.FindElement(By.Id("f2"));
        public IWebElement LastNameFieldEmergancy => Driver.FindElement(By.Id("l2"));

        public IWebElement FemaleRadioButton => Driver.FindElement(By.Id("radio1-f"));
        public IWebElement OtherRadioButton => Driver.FindElement(By.XPath("radio2-0"));
        public IWebElement FirstNameField => Driver.FindElement(By.Id("f1"));
        public IWebElement LastNameField => Driver.FindElement(By.Id("l1"));
        public ReadOnlyCollection<IWebElement> SubmitButton => Driver.FindElements(By.Id("submit2"));

        public IWebElement EntryTitle => Driver.FindElement(By.CssSelector(".entry-title.main_title"));       

      

       



        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-4/");
           // Assert.IsTrue(IsVisible); //to remove duplication in tests remove this line from the test method
        }

        public bool IsVisible => EntryTitle.Displayed;

        public void FillOutEmergencyForm(User testUser)
        {
            SetGenderForEmergencyContact(testUser);
            FirstNameFieldEmergancy.SendKeys(testUser.Firstname);
            LastNameFieldEmergancy.SendKeys(testUser.Lastname);
        }

        public UltimateQaHomePage FillOutFormAndSubmit(User testUser)
        {
            SetGender(testUser);
            FirstNameField.SendKeys(testUser.Firstname);
            LastNameField.SendKeys(testUser.Lastname);
            SubmitButton[0].Click();
            return new UltimateQaHomePage(Driver);
        }

        private void SetGenderForEmergencyContact(User testUser)
        {
            switch (testUser.GenderType)
            {
                case Gender.Female:
                    FemaleRadioButtonEmergency.Click();
                    break;
                case Gender.Other:
                    OtherRadioButtonEmergency.Click();
                    break;
                default:
                    break;
            }
        }

        private void SetGender(User testUser)
        {
            switch (testUser.GenderType)
            {
                case Gender.Female:
                    FemaleRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
    }
}