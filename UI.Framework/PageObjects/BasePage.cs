using OpenQA.Selenium;

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
        private IWebElement Logo => Driver.FindElement(By.XPath("(//*[@aria-label='iA Financial Group Logo'])[2]"));
        #endregion

        #region UI Usage
        public void GoToHomePage()
        {
            Logo.Click();
        }
        #endregion
    }
}
