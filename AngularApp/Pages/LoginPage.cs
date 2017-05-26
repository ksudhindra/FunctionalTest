using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protractor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Utils.Base;
using OpenQA.Selenium.Support.UI;

namespace AngularApp
{
    class LoginPage :BasePage
    {
        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByButtonText), Using = "Login")]
        IWebElement btnLogin { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "user.name")]
        IWebElement txtLogon { get; set; }


        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "user.password")]
        IWebElement txtPassword { get; set; }


        public LoginPage()
        {
            var wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(10));
            IWebElement searchResult = wait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Username')]")));

        }
        public EmployeePage Login()
        {
            txtLogon.SetText("Luke");
            txtPassword.SetText("Skywalker");
            btnLogin.CustomClick();
            return GetInstance<EmployeePage>();
        }


    }
}
