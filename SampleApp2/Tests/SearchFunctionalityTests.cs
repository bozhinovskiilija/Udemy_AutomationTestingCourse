using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp2.Pages;

namespace SampleApp2.Tests
{
    [TestClass]
    [TestCategory("Functional testing")]
    public class SearchFunctionalityTests : BaseTest
    {
       
        [TestMethod]
        public void TCID1()
        {
           var searchTerm = "Blouse";
           var homePage = new HomePage(Driver);
           homePage.GoTo();
           var searchPage = homePage.Search(searchTerm);
           Assert.IsFalse(searchPage.Contains(Item.Blouse),"Item" +searchTerm+" not found");
        }
    }
}
