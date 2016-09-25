using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ValTech
{
    public class MainPage
    {
        private const string Url = @"http://www.valtech.com/";
        private IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public readonly NavigationBar NavigationBar;

        public int NumberOfContactOffices => _driver.FindElements(By.XPath("//ul[@class='contactcities']/li")).Count;

        #region WebElements
        [FindsBy(How = How.Id, Using = "contacticon")]
        public IWebElement ContactButton { get; set; }

        [FindsBy(How = How.Id, Using = "navigation-toggle-button")]
        public IWebElement NavigationToggleButton { get; set; }

        [FindsBy(How = How.TagName, Using = "H1")]
        public IWebElement H1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Latest news')]")]
        public IWebElement LatestNewsSection { get; set; }
        #endregion

        public MainPage(IWebDriver webDriver)
        {
            _driver = webDriver;
            _wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
            NavigationBar = new NavigationBar(_driver);
            _driver.Navigate().GoToUrl(Url);
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver = null;
        }

        public void ToggleNavigationBar()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(NavigationToggleButton));
            NavigationToggleButton.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(NavigationBar.CasesLink));
        }
    }
}