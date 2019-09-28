using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp2.Pages;

namespace SampleApp2.Tests
{
    [TestClass]
    [TestCategory("Functional testing")]
   public class ComplicatedPageTests : BaseTest
    {
        [TestMethod]
        public void TCID6()
        {
            var complicatedPage = new ComplicatedPage(Driver);
            complicatedPage.GoTo();
            Assert.IsTrue(complicatedPage.isLoaded);

            complicatedPage.RandonStuffSection.FillOutForm("pero", "p@mail.com", "test");
            Assert.IsTrue(complicatedPage.RandonStuffSection.IsFormSubmitted,"page was not submitet successfully");
        }
    }
}
