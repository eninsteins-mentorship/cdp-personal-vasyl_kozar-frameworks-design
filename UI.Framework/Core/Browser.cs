using UI.Framework.PageObjects;
using UI.Framework.Wrappers;

namespace UI.Framework.Core
{
    public static class Browser
    {
        private static BrowserFactory browser = new BrowserFactory();

        public static void StartApp()
        {
            browser.Start();
            browser.GoToUrl();
        }

        public static void CloseApp()
        {
            browser.CloseApp();
        }

        public static T GetPage<T>() where T : BasePage
        {
            return browser.GetPage<T>();
        }
    }
}
