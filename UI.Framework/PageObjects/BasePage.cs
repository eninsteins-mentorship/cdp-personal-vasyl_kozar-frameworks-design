using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UI.Framework.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; set; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region UI Elements
        [FindsBy(How = How.XPath, Using = "(//*[@aria-label='iA Financial Group Logo'])[2]")]
        [CacheLookup]
        private IWebElement Logo;
        #endregion

        #region UI Usage
        public void GoToHomePage()
        {
            Logo.Click();
        }
        #endregion
    }
}
