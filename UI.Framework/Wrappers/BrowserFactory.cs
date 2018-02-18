using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Framework.Wrappers
{
    public class BrowserFactory
    {
        private IWebDriver Driver { get; set; }

        private string AppUrl { get; set; }

        public BrowserFactory()
        {
            AppUrl = ConfigurationManager.AppSettings["applicationURL"];
        }

        public void Start()
        {
            //TO DO
        }

        public void GoToUrl()
        {
            // TO DO
        }
    }
}
