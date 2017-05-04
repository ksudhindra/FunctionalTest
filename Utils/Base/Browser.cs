using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protractor;

namespace Utils.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;
        private readonly NgWebDriver _ngdriver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }



    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
