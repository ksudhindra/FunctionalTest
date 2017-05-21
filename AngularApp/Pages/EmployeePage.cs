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
    class EmployeePage :BasePage
    {
       // [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByButtonText), Using = "Create")]
        [FindsBy(How = How.Id,  Using = "bAdd")]
        IWebElement btnCreate { get; set; }
        //[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByButtonText), Using = "Edit")]
        [FindsBy(How = How.Id, Using = "bEdit")]
        IWebElement btnEdit { get; set; }
        //[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByButtonText), Using = "Delete")]
        [FindsBy(How = How.Id, Using = "bDelete")]
        IWebElement btnDelet { get; set; }


        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByRepeater), Using = "employee in employees")]
        public IList<IWebElement> lstEmployees { get; set; }

        public CreateEmployeePage CheckHighlightListItem()
        {
            btnCreate.CustomClick();
            return GetInstance<CreateEmployeePage>();
            /*if ((btnEdit != null) && (btnDelet != null)) {
                btnEdit.Click();
            //Assert.IsTrue(btnEdit.Enabled);
            //Assert.IsTrue(btnDelet.Enabled);
            }*/

        }

        public EditEmployeePage EditEmployee()
        {
            btnEdit.CustomClick();
            return GetInstance<EditEmployeePage>();
        }


    }
}
