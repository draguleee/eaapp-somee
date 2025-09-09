using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class CustomMethods
    {
        /// <summary>
        /// Clicks on a web element specified by the locator.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        /// <summary>
        /// Submits a web element specified by the locator.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void Submit(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Submit();
        }

        /// <summary>
        /// Sends keys to a web element specified by the locator.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        public static void SendKeys(IWebDriver driver, By locator, string value)
        {
            driver.FindElement(locator).SendKeys(value);
        }

        /// <summary>
        /// Selects an option from a dropdown by its value, text or index, depending on the attribute specified.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public static void SelectDropdown(IWebDriver driver, By locator, string text, string attribute)
        {
            var selectElement = new SelectElement(driver.FindElement(locator));
            switch (attribute)
            {
                case "text": selectElement.SelectByText(text); break;
                case "value": selectElement.SelectByValue(text); break;
                case "index": selectElement.SelectByIndex(int.Parse(text)); break;
                default: throw new ArgumentException("Invalid attribute specified. Use 'text', 'value', or 'index'.");
            }
        }

        /// <summary>
        /// Selects multiple options from a multi-select dropdown by their values, texts or indexes, depending on the attribute specified.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="values"></param>
        /// <param name="attribute"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void MultiSelect(IWebDriver driver, By locator, string[] values, string attribute)
        {
            var selectElement = new SelectElement(driver.FindElement(locator));
            foreach (var value in values)
            {
                switch (attribute)
                {
                    case "value": selectElement.SelectByValue(value); break;
                    case "index": selectElement.SelectByIndex(int.Parse(value)); break;
                    case "text": selectElement.SelectByText(value); break;
                    default: throw new ArgumentException("Invalid attribute specified. Use 'text', 'value', or 'index'.");
                }
            }
        }

        /// <summary>
        /// Gets all selected options from a multi-select dropdown and returns them as a list of strings.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static List<string> GetSelectedOptions(IWebDriver driver, By locator)
        {
            List<string> options = new List<string>();
            var multiSelect = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;
            foreach (var option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
    }
}
