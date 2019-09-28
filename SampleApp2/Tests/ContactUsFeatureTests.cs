using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp2.Pages;

namespace SampleApp2.Tests
{
    [TestClass]
    [TestCategory("Functional testing")]
    public class ContactUsFeatureTests : BaseTest
   {
      
 
        [TestMethod]
        [Description("validate that contact us page opens successfully")]
        [TestProperty("Author","ilijaBozhinovski")]
        public void TCID2()
        {
            var contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();            
            Assert.IsTrue(contactUsPage.IsLoaded);
        }


        [TestMethod]
        [Description("validate that contact us page opens when clicking on Contact Us button")]
        [TestProperty("Author", "ilijaBozhinovski")]
        public void TCID4()
        {
            var homepage = new HomePage(Driver);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsLoaded,"Home page did not open successfully");

            var contactUsPage = homepage.Header.ClickContactUsButton();

            Assert.IsTrue(contactUsPage.IsLoaded);
        }
    }
}
