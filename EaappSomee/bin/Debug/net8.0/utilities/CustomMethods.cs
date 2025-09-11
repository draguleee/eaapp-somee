namespace EaappSomee.utilities
{
    public static class CustomMethods
    {
        /// <summary>
        /// Clicks on a web element specified by the locator.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        /// <summary>
        /// Submits a web element specified by the locator.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void Submit(this IWebElement locator)
        {
            locator.Submit();
        }

        /// <summary>
        /// Sends keys to a web element specified by the locator.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        public static void SendKeys(this IWebElement locator, string value)
        {
            locator.Clear();
            locator.SendKeys(value);
        }

        /// <summary>
        /// Selects an option from a dropdown by its value, text or index, depending on the attribute specified.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public static void SelectDropdown(this IWebElement locator, string text, string attribute)
        {
            var selectElement = new SelectElement(locator);
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
        public static void MultiSelect(this IWebElement locator, string[] values, string attribute)
        {
            var selectElement = new SelectElement(locator);
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
        public static List<string> GetSelectedOptions(this IWebElement locator)
        {
            List<string> options = new List<string>();
            var multiSelect = new SelectElement(locator);
            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;
            foreach (var option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
    }
}
