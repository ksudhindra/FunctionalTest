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

            DriverContext.Driver = new ChromeDriver();
            DriverContext.Browser = new Browser(DriverContext.Driver);
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            DriverContext.Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            _ngdriver = new NgWebDriver(DriverContext.Driver);
            _ngdriver.Navigate().GoToUrl(baseURL);
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
            CurrentPage =  CurrentPage.As<EmployeePage>().CheckHighlightListItem();
            CurrentPage.As<CreateEmployeePage>().AddEmployee();

        }

        public void ValidateEmployeePage()
        {

        }


    }
}
