using OpenQA.Selenium;

namespace UI.Framework.PageObjects
{
    public class MortgagePage : BasePage
    {
        public MortgagePage(IWebDriver driver) : base(driver)
        {
        }

        #region UI Elements
        private IWebElement calculateYourPayments => Driver.FindElement(By.XPath("//a[@href='/mortgage-payment-calculator' and @class='btn-full']"));
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
