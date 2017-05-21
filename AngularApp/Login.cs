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

namespace AngularApp
{
    [TestFixture]
    public class Login : Base
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string baseURL = "http://cafetownsend-angular-rails.herokuapp.com";
        private NgWebDriver _ngdriver;

        [SetUp]
        public void Setup()
        {
            //log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(@"C:\Personal\MoveOut\QA Role\Assessment_LEAP\Code\FunctionalTest\FunctionalTest\AngularApp\bin\Debug\LoggerConfig.xml"));
            LogHelper.Intialize();
            LogHelper.FrameworkLogger.Info("Logger Initialized");
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Browser = new Browser(DriverContext.Driver);
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LogHelper.FrameworkLogger.Info("Testing the frameworklogger");
            LogHelper.FrameworkLogger.Info("Setting the Implicit wait time to 10 seconds");
            DriverContext.Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            LogHelper.FrameworkLogger.Info("Setting the Scripttimeout to 10 seconds");
            _ngdriver = new NgWebDriver(DriverContext.Driver);
            _ngdriver.Navigate().GoToUrl(baseURL);
            LogHelper.FrameworkLogger.Info("Navigating to " + baseURL);
        }
        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void EnterWebSite()
        {
            /*var loginField = _ngdriver.FindElement(NgBy.Model("user.name"));
            loginField.SendKeys("Luke");
            var passworkField = _ngdriver.FindElement(NgBy.Model("user.password"));
            passworkField.SendKeys("Skywalker");
            var loginButon = _ngdriver.FindElement(NgBy.ButtonText("Login"));
            loginButon.Click();*/
            BasePage CurrentPage =  GetInstance<LoginPage>();
            //LoginPage lPage = new LoginPage();
            //lPage.Login();
            CurrentPage = CurrentPage.As<LoginPage>().Login();
            List<IWebElement> checkEmployees = CurrentPage.As<EmployeePage>().lstEmployees.ToList();
            foreach(IWebElement employee in checkEmployees)
            {
                Assert.IsNotNull(employee.Text);
                //Console.WriteLine(employee.Text);
            }
            checkEmployees.FirstOrDefault().Click();
            CurrentPage = CurrentPage.As<EmployeePage>().EditEmployee();
            //CurrentPage =  CurrentPage.As<EmployeePage>().CheckHighlightListItem();
            //CurrentPage.As<CreateEmployeePage>().AddEmployee();
            //CurrentPage = CurrentPage.As<CreateEmployeePage>().NavigateBack();
            CurrentPage.As<EditEmployeePage>().Append_String_To_Name();

        }

        public void ValidateEmployeePage()
        {

        }


    }
}
