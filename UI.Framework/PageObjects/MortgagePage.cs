using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UI.Framework.PageObjects
{
    public class MortgagePage : BasePage
    {
        public MortgagePage(IWebDriver driver) : base(driver)
        {
        }

        #region UI Elements
        [FindsBy(How = How.XPath, Using = "//a[@href='/mortgage-payment-calculator' and @class='btn-full']")]
        [CacheLookup]
        private IWebElement calculateYourPayments;
        #endregion

        #region UI Usage
        /// <summary>
        /// This method clicks the Calculate Your Payments button. Returns nothing.
        /// </summary>
        /// <returns></returns>
        public void ClickOnCalculateYourPaymentsBtn()
        {
            calculateYourPayments.Click();
        }
        #endregion
    }
}
