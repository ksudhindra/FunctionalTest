using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Protractor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Utils.Base;
using Utils;
using Utils.Logger;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace AngularApp
{
    [TestFixture]
    public class Login : Base
    {
        private string baseURL = "http://cafetownsend-angular-rails.herokuapp.com";
        private NgWebDriver _ngdriver;

        [SetUp]
        public void Setup()
        {
            LogHelper.Intialize();
            LogHelper.FrameworkLogger.Info("Logger Initialized");
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Browser = new Browser(DriverContext.Driver);
            LogHelper.FrameworkLogger.Info("Testing the frameworklogger");
            LogHelper.FrameworkLogger.Info("Setting the Implicit wait time to 10 seconds");
            DriverContext.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            LogHelper.FrameworkLogger.Info("Setting the Scripttimeout to 10 seconds");
            _ngdriver = new NgWebDriver(DriverContext.Driver);
            _ngdriver.Navigate().GoToUrl(baseURL);
            

            //LogHelper.FrameworkLogger.Info("Navigating to " + baseURL);
        }
        [TearDown]
        public void TearDown()
        {
            LogHelper.FrameworkLogger.Info("Closing the Broswer sesion");
            GetInstance<EmployeePage>().Logout();
            //DriverContext.Driver.Close();
        }

        [Test]
        public void EnterWebSite()
        {
            BasePage CurrentPage =  GetInstance<LoginPage>();

            CurrentPage = CurrentPage.As<LoginPage>().Login();
            List<IWebElement> checkEmployees = CurrentPage.As<EmployeePage>().lstEmployees.ToList();
            LogHelper.FrameworkLogger.Info(string.Format("Found {0} employees", checkEmployees.Count));
            /*foreach(IWebElement employee in checkEmployees)
            {
                Assert.IsNotNull(employee.Text);
                Console.WriteLine(employee.Text);
            }*/
            /*for(int i = 1; i < 100; i++)
            {
                checkEmployees = CurrentPage.As<EmployeePage>().lstEmployees.ToList();
                LogHelper.FrameworkLogger.Info(string.Format("Found {0} employees", checkEmployees.Count));
                Random rand = new Random();
                checkEmployees[rand.Next(1, checkEmployees.Count)].Click();
                CurrentPage = CurrentPage.As<EmployeePage>().EditEmployee();
                //CurrentPage =  CurrentPage.As<EmployeePage>().CheckHighlightListItem();
                //CurrentPage.As<CreateEmployeePage>().AddEmployee();
                //CurrentPage = CurrentPage.As<CreateEmployeePage>().NavigateBack();
                CurrentPage = CurrentPage.As<EditEmployeePage>().Append_String_To_Name();

            }*/

                foreach(IWebElement elem in checkEmployees)
                {
                    //Match result = Regex.Match(elem.Text, @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}");
                    //if(result.Success)
                    {
                        LogHelper.FrameworkLogger.Info(string.Format("deletig the {0} entry", elem.Text));
                        CurrentPage.As<EmployeePage>().SelectEmployee(elem.Text).CustomClick();
                        //elem.CustomClick();
                        CurrentPage.As<EmployeePage>().DeleteEmlpoyee();
                        
                    }
                break;

                }
            


        }

        public void ValidateEmployeePage()
        {

        }


    }
}
