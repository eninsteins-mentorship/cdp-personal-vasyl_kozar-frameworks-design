using NUnit.Framework;
using System.Threading;
using UI.Framework.Common;
using UI.Framework.Core;
using UI.Framework.PageObjects;

namespace IA_CA
{
    [TestFixture]
    public class IaTests
    {

        [SetUp]
        public void BeforeTest()
        {
            Browser.StartApp();
        }

        [Test]
        public void MortgagePaymentCalculatorTest()
        {
            // 2. Click LOANS and 3. Click the Mortgages link
            var individualsPage = Browser.GetPage<IndividualsPage>();
            individualsPage.ClickOnTheMortgagesLink();


            // 4. Click the Calculate Your Payments button
            var mortgagePage = Browser.GetPage<MortgagePage>();
            mortgagePage.ClickOnCalculateYourPaymentsBtn();

            // 5. Move the Purchase Price Slider to the right
            var mortgagePaymentCalculatorPage = Browser.GetPage<MortgagePaymentCalculatorPage>();
            mortgagePaymentCalculatorPage.SlidePurchasePrice(30);

            // 6. Validate that the Purchase Price Slider movement works
            StringAssert.AreEqualIgnoringCase("108348", mortgagePaymentCalculatorPage.GetPurchasePriceValue());

            // 7. Change the Purchase Price to 500 000 using the + button of the slider
            mortgagePaymentCalculatorPage.CleanPurchasePriceField();
            mortgagePaymentCalculatorPage.ClickPurchasePricePlusBtn(2);

            // 8. Change the Down Payment to 40 000 using the + button of the slider
            mortgagePaymentCalculatorPage.ClickDownPaymentPlusBtn(4);

            // 9. Select 15 years for Amortization
            mortgagePaymentCalculatorPage.SelectAmortization((int)Amortization.YEARS15);

            // 10. Select Weekly for Payment Frequency
            mortgagePaymentCalculatorPage.SelectPaymentFrequency((int)Frequency.WEEKLY);

            // 11. Change the Interest Rate to 5%
            mortgagePaymentCalculatorPage.SpecifyInterestRate(5.0);

            // 12. Click the Calculate button
            mortgagePaymentCalculatorPage.clickCalculateBtn();

            // Verify that the weekly payments value is 181.59
            Thread.Sleep(3000);
            StringAssert.AreEqualIgnoringCase("197.03", mortgagePaymentCalculatorPage.getPaiementResult());
        }

        [TearDown]
        public void AfterTest()
        {
            Browser.CloseApp();
        }
    }
}
