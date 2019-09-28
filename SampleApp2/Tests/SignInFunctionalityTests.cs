using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp2.Pages;

namespace SampleApp2.Tests
{
    [TestClass]
    [TestCategory("Functional testing")]
    public class SignInFunctionalityTests : BaseTest
    {
        [TestMethod]
        public void TCID5()
        {
            var homepage = new HomePage(Driver);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsLoaded, "Home page did not open successfully");

            var signInPage = homepage.Header.ClickSignInButton();

            Assert.IsTrue(signInPage.isLoaded,"Sign in pase is not loaded successfully");
        }
    }
}
