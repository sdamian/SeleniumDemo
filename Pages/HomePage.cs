using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumDemo.Pages
{
    class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly IWait<IWebDriver> _wait;

        public HomePage(IWebDriver driver, IWait<IWebDriver> wait)
        {
            _driver = driver;
            _wait = wait;
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("rotator2")));
        }

        public IWebElement Woning => _driver.FindElement(By.CssSelector(".woning"));
    }
}