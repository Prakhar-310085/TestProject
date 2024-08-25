using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class Checkout
    {
        private readonly IWebDriver _driver;

        public Checkout(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement CheckoutButton => _driver.FindElement(By.Id("checkout"));
        private IWebElement FirstName => _driver.FindElement(By.Id("first-name"));
        private IWebElement LastName => _driver.FindElement(By.Id("last-name"));
        private IWebElement ZipCode => _driver.FindElement(By.Id("postal-code"));
        private IWebElement ContinueButton => _driver.FindElement(By.Id("continue"));
        private IWebElement FinishButton => _driver.FindElement(By.Id("finish"));
        public void Checkoutbuttonclick()
        {
            CheckoutButton.Click();
        }
        public void EnterDetails()
        {
            FirstName.SendKeys("bob");
            LastName.SendKeys("steve");
            ZipCode.SendKeys("12345");
            ContinueButton.Click();
            FinishButton.Click();
        }
    }

}
