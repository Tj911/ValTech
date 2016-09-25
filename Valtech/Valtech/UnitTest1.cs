using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace ValTech
{
    [TestClass]
    public class UnitTest
    {
        const int EXPECTEDNUMBEROFCITIES = 30;
        private MainPage _page;

        #region Setup / Teardown
        [TestInitialize]
        public void Setup()
        {
            _page = new MainPage(new ChromeDriver());
        }

        [TestCleanup]
        public void Teardown()
        {
            _page.Dispose();
            _page = null;
        }
        #endregion

        [TestMethod]
        [TestCategory("Home page")]
        public void Homepage_LatestNewsSection_IsPresent()
        {
            Assert.AreEqual("LATEST NEWS", _page.LatestNewsSection.Text, "Latest-News section is absent");
        }

        [TestMethod]
        [TestCategory("ContactUs page")]
        public void HomePage_ContactUsPage_ContactOffices()
        {
            _page.ContactButton.Click();
            Assert.AreEqual(EXPECTEDNUMBEROFCITIES, _page.NumberOfContactOffices, "Expected number of Contact page Cities is incorrect");
        }

        [TestMethod]
        [TestCategory("Navigation")]
        [TestCategory("Cases")]
        public void HomePage_CasesPage_H1()
        {
            _page.ToggleNavigationBar();
            _page.NavigationBar.CasesLink.Click();
            Assert.AreEqual("Cases", _page.H1.Text, "H1 heading is incorrect");
        }

        [TestMethod]
        [TestCategory("Navigation")]
        [TestCategory("Jobs")]
        public void HomePage_JobsPage_H1()
        {
            _page.ToggleNavigationBar();
            _page.NavigationBar.JobsLink.Click();
            Assert.AreEqual("Jobs", _page.H1.Text, "H1 heading is incorrect");
        }

        [TestMethod]
        [TestCategory("Navigation")]
        [TestCategory("Services")]
        public void HomePage_ServicesPage_H1()
        {
            _page.ToggleNavigationBar();
            _page.NavigationBar.ServiceLink.Click();
            Assert.AreEqual("Services", _page.H1.Text, "H1 heading is incorrect");
        }
    }
}
