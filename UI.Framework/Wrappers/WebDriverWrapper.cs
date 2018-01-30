using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UI.Framework.Wrappers
{
    public class WebDriverWrapper
    {
        private static IWebDriver driver;

        private WebDriverWrapper() { }

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
                return driver;
            }
        }
    }
}
