using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UI.Framework.PageObjects
{
    public class MortgagePaymentCalculatorPage : BasePage
    {
        public MortgagePaymentCalculatorPage(IWebDriver driver) : base(driver)
        {
        }

        #region UI Elements
        private IWebElement purchasePriceSlider => Driver.FindElement(By.XPath("//div[@class='row']//button[@id='PrixProprieteMinus']/../*[2]/*/div[@class='slider-handle min-slider-handle custom']"));

        private IWebElement purchasePriceInput => Driver.FindElement(By.XPath("//*[@id='PrixPropriete']"));

        private IWebElement purchasePricePlusBtn => Driver.FindElement(By.XPath("//*[@id='PrixProprietePlus']"));

        private IWebElement purchasePriceMinusBtn => Driver.FindElement(By.XPath("//button[@id='PrixProprieteMinus']"));

        private IWebElement downPaymentSlider => Driver.FindElement(By.XPath("//div[@class='row']//button[@id='MiseDeFondMinus']/../*[2]/*/div[@class='slider-handle min-slider-handle custom']"));

        private IWebElement downPaymentPlusBtn => Driver.FindElement(By.XPath("//*[@id='MiseDeFondPlus']"));

        private IWebElement amortizationBtn => Driver.FindElement(By.XPath("//div[@class='col-med-1-2 col-lg-1-3']//b[@class='button']"));

        private IWebElement paymentFrequencyBtn => Driver.FindElement(By.XPath("//div[@class='selectric-wrapper selectric-responsive']//b"));

        private IWebElement interestRateField => Driver.FindElement(By.XPath("//*[@id='TauxInteret']"));

        private IWebElement calculateBtn => Driver.FindElement(By.XPath("//*[@id='btn_calculer']"));

        private IWebElement paiementResult => Driver.FindElement(By.XPath("//*[@class='resultats']"));
        #endregion

        #region UI Usage
        /// <summary>
        /// This method moves the Purchase Price slider to the right. Returns nothing.
        /// </summary>
        /// <param name="sliderWidth">Offset X</param>
        public void SlidePurchasePrice(int sliderWidth)
        {
            Actions builder = new Actions(Driver);
            builder.MoveToElement(purchasePriceSlider)
                   .Click()
                   .DragAndDropToOffset(purchasePriceSlider, sliderWidth, 0)
                   .Build()
                   .Perform();
        }

        /// <summary>
        /// This method gets value of Purchase price field.
        /// </summary>
        /// <returns>string</returns>
        public string GetPurchasePriceValue()
        {
            return purchasePriceInput.GetAttribute("value");
        }

        /// <summary>
        /// This method cleans Purchase price field. Returns nothing.
        /// </summary>
        public void CleanPurchasePriceField()
        {
            for (int item = 0; item < 9; item++)
            {
                purchasePriceMinusBtn.Click();
            }
        }

        /// <summary>
        /// This method click on the "+" button of the Purchase Price slider. Returns nothing.
        /// </summary>
        /// <param name="times">Times to run.</param>
        public void ClickPurchasePricePlusBtn(int times)
        {
            for (int item = 1; item <= times; item++)
            {
                purchasePricePlusBtn.Click();
            }
        }

        /// <summary>
        /// This method click on the "+" button of the Down Payment slider. Returns nothing. 
        /// </summary>
        /// <param name="times">Times to run.</param>
        public void ClickDownPaymentPlusBtn(int times)
        {
            for (int item = 1; item <= times; item++)
            {
                downPaymentPlusBtn.Click();
            }
        }

        /// <summary>
        /// This method selects value from Amortization fields. Returns nothing.
        /// </summary>
        /// <param name="amortizationEnum">use Amortization type</param>
        public void SelectAmortization(int amortizationEnum)
        {
            string amortizationPath = "//div[@class='col-med-1-2 col-lg-1-3']//ul//*[";
            amortizationBtn.Click();
            amortizationEnum++;
            int item = amortizationEnum;
            IWebElement amortizationSelect = Driver.FindElement(By.XPath(amortizationPath + item + "]"));
            amortizationSelect.Click();
        }

        /// <summary>
        /// This method selects value from Payment Frequency field. Returns nothing.
        /// </summary>
        /// <param name="paymentFrequency">use PaymentFrequency type</param>
        public void SelectPaymentFrequency(int paymentFrequency)
        {
            string paymentFrequencyPath = "//*[@id='FrequenceVersement']//..//..//div[@class='selectric-scroll']//ul//*[";
            paymentFrequencyBtn.Click();
            paymentFrequency++;
            int item = paymentFrequency;
            IWebElement paymentFrequencySelect = Driver.FindElement(By.XPath(paymentFrequencyPath + item + "]"));
            paymentFrequencySelect.Click();
        }

        /// <summary>
        /// This method inserts value to the Interest Rate field. Returns nothing. 
        /// </summary>
        /// <param name="rate">Rate %</param>
        public void SpecifyInterestRate(double rate)
        {
            interestRateField.Clear();
            interestRateField.SendKeys(rate.ToString());
        }

        /// <summary>
        /// Method clicks Calculate button. Returns nothing.
        /// </summary>
        public void clickCalculateBtn()
        {
            calculateBtn.Click();
        }

        /// <summary>
        /// Method returns calculation result.
        /// </summary>
        /// <returns></returns>
        public string getPaiementResult()
        {
            string[] result = paiementResult.Text.Split(' ');
            return result[6];
        }
        #endregion
    }
}
