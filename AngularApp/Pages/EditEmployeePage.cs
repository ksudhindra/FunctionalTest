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
using NUnit.Framework;

namespace AngularApp
{
    class EditEmployeePage : BasePage
    {
        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.firstName")]
        public IWebElement firstName;

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.lastName")]
        public IWebElement lastName;

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.startDate")]
        public IWebElement startDate;

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.email")]
        public IWebElement email;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Update')]")]//ng-show="isCreateForm"
        IWebElement btnUpdate { get; set; }

        [FindsBy(How = How.LinkText, Using = "Back")]
        IWebElement btnCancel { get; set; }

        public void Append_String_To_Name()
        {
            string firstNameValue = firstName.Text + "appendedValue";
            firstName.SetText(firstNameValue);
            btnUpdate.CustomClick();
        }
    }
}
