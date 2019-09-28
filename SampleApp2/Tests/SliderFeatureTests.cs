using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp2.Pages;

namespace SampleApp2.Tests
{
    [TestClass]
    [TestCategory("Functional testing")]
    public class SliderFeatureTests : BaseTest
    {
        [TestMethod]
        public void TCID3()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            var currentImage = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();
            var newImage = homePage.Slider.CurrentImage;
            Assert.AreNotEqual(currentImage, newImage);
        }
    }
}