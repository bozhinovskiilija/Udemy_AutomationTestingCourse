using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        public IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // var driver = new ChromeDriver();
             driver = GetChromeDriver();
             driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
           driver.Quit();
        }



        [TestMethod]
        public void TestMethod1()
        {
           
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Navigate().Refresh();
            driver.Navigate().Back();
            driver.Navigate().Forward();

            // -->   //*[@id='button1']/..     --> takes the parent element of the element with id=button1
            // -->   //*[contains(text(),'Click Me')] 
            // -->   //*[@type='submit'][@id='button2']
        }

        [TestMethod]
        public void SeleniumElementLocationExam()
        {

            driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");

            var element =   driver.FindElement(By.XPath("//*[@type='radio'][@value='male']"));
            var element2 = driver.FindElement(By.XPath("//*[@value='Bike']"));

            var elemenet3 = driver.FindElement(By.TagName("Select"));
            var element31 = driver.FindElement(By.XPath("//*[@value='opel']"));

            var element4 = driver.FindElement(By.XPath("//li[@class='et_pb_tab_1']"));


            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            // js.ExecuteScript("arguments[0].scrollIntoView();", element);
            js.ExecuteScript("window.scrollBy(0,1200)");

            //element.Click();
            //element2.Click();
            //elemenet3.Click();
           // element31.Click();

           element4.Click();

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
           Thread.Sleep(2000);

           WebDriverWait wait= new WebDriverWait(driver,TimeSpan.FromSeconds(2));

           wait.Until(ExpectedConditions.ElementIsVisible(By.Id("idOfElement"))).Click();
           //wait.Until(ElementIsVisible(By.Id("idOfElement"))).Click();
            //IWebElement element6 = wait.Until(d =>
            //{
            //    return d.FindElement(By.Id("idname"));
            //});

            Assert.AreEqual("Tab 2",element4.Text);
        }

        [TestMethod]
        public void TDD_283()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/");
           
           // var searchIcon = driver.FindElement(By.Id("et_search_icon"));
           // searchIcon.Click();

            Actions action = new Actions(driver);

            action.MoveToElement(driver.FindElement(By.Id("et_search_icon")))
                  .Click()
                  .Perform();

            var searchInputField = driver.FindElement(By.ClassName("et-search-field"));
            searchInputField.SendKeys("complicated page");
            searchInputField.Submit();

            var complitatedPageLink =
                driver.FindElement(By.XPath("//*[@href='https://www.ultimateqa.com/complicated-page/']"));

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView();", complitatedPageLink);
            //js.ExecuteScript("window.scrollBy(0,1200)");

            complitatedPageLink.Click();

          

        }






        private IWebDriver GetChromeDriver()
        {
            var pathToDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //goes to bin folder
            return new ChromeDriver(pathToDriver);
        }


    }
}
