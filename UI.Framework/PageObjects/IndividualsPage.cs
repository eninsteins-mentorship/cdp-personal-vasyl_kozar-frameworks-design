using OpenQA.Selenium;

namespace UI.Framework.PageObjects
{
    public class IndividualsPage : BasePage
    {
        public IndividualsPage(IWebDriver driver) : base(driver)
        {
        }

        #region UI Elements
        private IWebElement mortgagesLink => Driver.FindElement(By.XPath("//a[@href='/mortgage' and @data-utag-name='mortgage_loan']"));

        private IWebElement loans => Driver.FindElement(By.XPath("//li[@class='dropdown Pret three-items ']"));
        #endregion

        #region UI Usage
        /// <summary>
        /// This method clicks LOANS and clicks Mortgages link. Returns nothing. 
        /// </summary>
        public void ClickOnTheMortgagesLink()
        {
            loans.Click();
            mortgagesLink.Click();
        }
        #endregion
    }
}
