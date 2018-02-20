using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using UI.Framework.PageObjects;

namespace UI.Framework.Wrappers
{
    public class BrowserFactory
    {
        private IWebDriver Driver { get; set; }

        private string AppUrl { get; set; }

        public BrowserFactory()
        {
            // Reading url from App.config file
            AppUrl = ConfigurationManager.AppSettings["applicationURL"];
        }

        /// <summary>
        /// Method opens browser.
        /// </summary>
        public void Start()
        {
            var chromeOptions = new ChromeOptions();
            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Method navigates to page using direct url
        /// </summary>
        /// <param name="navigateUrl">url string</param>
        public void GoToUrl(string navigateUrl = "")
        {
            Driver.Navigate().GoToUrl(AppUrl + navigateUrl);
        }

        /// <summary>
        /// Method closes browser
        /// </summary>
        public void CloseApp()
        {
            Driver?.Quit();
        }

        /// <summary>
        /// Method  initializes page
        /// </summary>
        /// <typeparam name="T">page type</typeparam>
        /// <returns> returns proper page object</returns>
        public T GetPage<T>() where T : BasePage
        {
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }
    }
}
