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

        /*public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }*/

        public EmployeePage Login()
        {
            

            txtLogon.SendKeys("Luke");
            txtPassword.SendKeys("Skywalker");
            btnLogin.Click();
            return GetInstance<EmployeePage>();
        }


    }
}
