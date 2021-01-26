using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumDemo.Pages
{
    class WrapperPage
    {
        private readonly IWebDriver _driver;
        private readonly IWait<IWebDriver> _wait;

        public static WrapperPage Open(IWebDriver driver, IWait<IWebDriver> wait, string baseUrl)
        {
            driver.Navigate().GoToUrl(baseUrl + "/wrapper");
            return new WrapperPage(driver, wait);
        }

        public WrapperPage(IWebDriver driver, IWait<IWebDriver> wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement ContractInput => _driver.FindElement(By.Id("contract"));
        public IWebElement OpenButton => Buttons.Single(x => x.Text.StartsWith("Open"));
        private IEnumerable<IWebElement> Buttons => _driver.FindElements(By.TagName("button"));
        
        public void SetContract(string contractNumber)
        {
            ContractInput.Clear();
            ContractInput.SendKeys(contractNumber);
        }

        public HomePage OpenCustomer()
        {
            OpenButton.Click();
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));
            _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("rotator2")));
            return new HomePage(_driver, _wait);
        }
    }
}