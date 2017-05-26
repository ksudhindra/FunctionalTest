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
using OpenQA.Selenium.Support.UI;
using Utils.Logger;

namespace AngularApp
{
    class EmployeePage :BasePage,IDisposable
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

        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'Logout')]")]
        IWebElement btnLogOut { get; set; }


        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByRepeater), Using = "employee in employees")]
        public IList<IWebElement> lstEmployees { get; set; }

        public EmployeePage()
        {
            new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(20)).
   Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.XPath("//ul/li[contains(@ng-repeat,'employee in employees')]"))));


        }

        public CreateEmployeePage CheckHighlightListItem()
        {
            btnCreate.CustomClick();
            return GetInstance<CreateEmployeePage>();

        }

        public EditEmployeePage EditEmployee()
        {
            btnEdit.CustomClick();
            return GetInstance<EditEmployeePage>();
        }

        public void DeleteEmlpoyee()
        {
            try
            {
                new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("bDelete")));
                btnDelet.CustomClick();
                new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.AlertIsPresent());

                if(DriverContext.Driver.SwitchTo().Alert().Text.Contains("Error trying to delete an employee"))
                {
                    LogHelper.FrameworkLogger.Error("Error deleting the record");
                    DriverContext.Driver.SwitchTo().Alert().Dismiss();

                }
                else
                {
                    DriverContext.Driver.SwitchTo().Alert().Accept();
                }
            }
            catch (UnhandledAlertException ex)
            {
                LogHelper.FrameworkLogger.Error(string.Format("Delete failed"));
            }
            catch(NoAlertPresentException ex)
            {
                LogHelper.FrameworkLogger.Error(ex.Message);
            }
            catch(WebDriverTimeoutException ex)
            {
                LogHelper.FrameworkLogger.Error(ex.Message);
            }
            
            finally
            {
               
            }
            CurrentPage = GetInstance<EmployeePage>();
        }

        public void Dispose()
        {
            LogHelper.FrameworkLogger.Info("Disposing the employee page instance");
        }

        
        public IWebElement SelectEmployee(string name)
        {
            string xPathConstruct = "//ul/li[contains(text(), '"+ name+"')]";
            return  DriverContext.Driver.FindElement(By.XPath(xPathConstruct));

        }
       
        public void Logout()
        {
            LogHelper.FrameworkLogger.Info("Logging out");
            btnLogOut.CustomClick();
        }
    }
}
