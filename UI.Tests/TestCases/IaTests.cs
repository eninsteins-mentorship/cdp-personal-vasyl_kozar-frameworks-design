using NUnit.Framework;
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
        public void TestMethod1()
        {
            var individualsPage = Browser.GetPage<IndividualsPage>();
            individualsPage.ClickOnTheMortgagesLink();
        }

        [TearDown]
        public void AfterTest()
        {
            Browser.CloseApp();
        }
    }
}
