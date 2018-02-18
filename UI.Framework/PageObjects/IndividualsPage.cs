using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UI.Framework.PageObjects
{
    public class IndividualsPage : BasePage
    {
        public IndividualsPage(IWebDriver driver) : base(driver)
        {
        }

        #region UI Elements
        [FindsBy(How = How.XPath, Using = "//a[@href='/mortgage' and @data-utag-name='mortgage_loan']")]
        [CacheLookup]
        private IWebElement mortgagesLink;

        [FindsBy(How = How.XPath, Using = "//li[@class='dropdown Pret three-items ']")]
        [CacheLookup]
        private IWebElement loans;
        #endregion

        #region UI Usage
        /// <summary>
        /// This method clicks LOANS and clicks Mortgages link. Returns nothing. 
        /// </summary>
        public MortgagePage ClickOnTheMortgagesLink()
        {
            loans.Click();
            mortgagesLink.Click();
            return new MortgagePage(driver);
        }
        #endregion
    }
}
