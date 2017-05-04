using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Base;

namespace AngularApp
{
    class CreateEmployeePage : BasePage
    {
        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.firstName")]
        public IWebElement firstName;

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.lastName")]
        public IWebElement lastName;

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.startDate")]
        public IWebElement startDate;

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.email")]
        public IWebElement email;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Add')]")]//ng-show="isCreateForm"
        IWebElement btnAdd { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cancel")]
        IWebElement btnCancel { get; set; }

        public void AddEmployee()
        {
            firstName.SendKeys("Procfirst1");
            lastName.SendKeys("Proclast1");
            startDate.SendKeys("2017-01-01");
            email.SendKeys("Procfirst1@Procfirst1.com");
            btnAdd.Click();
        }

    }
}
