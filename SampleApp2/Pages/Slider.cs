using OpenQA.Selenium;
using SampleApp2.Pages;

namespace SampleApp2
{
   public class Slider : BasePage
    {
        public Slider (IWebDriver driver) : base(driver) { }

        public string CurrentImage => Driver.FindElement(By.Id("homeslider")).GetAttribute("style");
        public void ClickNextButton()
        {
            Driver.FindElement(By.ClassName("bx-next")).Click();
            Reporter.LogPassingTestStepToBugLogger("Click the next button in the slider.");
        }
    }
}
