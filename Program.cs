using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages;

namespace SeleniumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // see https://www.selenium.dev/documentation/en/
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            using IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Size = new Size(375, 812);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            try
            {
                var wrapper = WrapperPage.Open(driver, wait, "https://aab-web-dev08");
                wrapper.SetContract("400014459");
            
                var customerPage = wrapper.OpenCustomer();

                Console.WriteLine("========================");
                Console.WriteLine(customerPage.Woning.Text);
                Console.WriteLine("========================");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            string screenShot = Path.GetFullPath("screenshot.png");
            driver.TakeScreenshot().SaveAsFile(screenShot);
            OpenScreenshot(screenShot);
        }

        private static void OpenScreenshot(string screenShot)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = screenShot,
                UseShellExecute = true,
            });
        }
    }
}
