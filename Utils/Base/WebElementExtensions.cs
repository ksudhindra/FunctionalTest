using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;

namespace Utils.Base
{
    public static class WebElementExtensions
    {
        public static void SetText(this IWebElement element, string value)
        {
            LogHelper.FrameworkLogger.Info(string.Format("Setting the {0} to value {1}", element.GetAttribute("ng-model"), value));
            element.SendKeys(value);
        }

        public static void CustomClick(this IWebElement element)
        {
            LogHelper.FrameworkLogger.Info(string.Format("Clicking the {0} ", element.Text));
            element.Click();
        }
    }
}
