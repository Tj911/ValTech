using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ValTech
{
    public class NavigationBar
    {
        private IWebDriver _driver;

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[@title='Cases']")]
        public IWebElement CasesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Services']")]
        public IWebElement ServiceLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Jobs']")]
        public IWebElement JobsLink { get; set; }
        #endregion

        public NavigationBar(IWebDriver webDriver)
        {
            _driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
    }
}
