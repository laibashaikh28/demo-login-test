using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit;

namespace LoginDemo.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly ScenarioContext _scenarioContext;
        public IWebDriver driver;
        public LoginStepDefinitions(ScenarioContext scenarioContext, ISpecFlowOutputHelper outputHelper)
        {
            _specFlowOutputHelper = outputHelper;
            _scenarioContext = scenarioContext;
        }
        [Given(@"user is at the Login page")]
        public void GivenUserIsAtTheLoginPage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");

            driver = new ChromeDriver(options);
           
            //Launch the Online Store Website
            driver.Url = "https://demoqa.com/login";
        }

        [When(@"user enters '(.*)' and '(.*)'")]
        public void WhenUserEntersAnd(string userName, string password)
        {
            driver.FindElement(By.Id("userName")).SendKeys(userName);

            driver.FindElement(By.Id("password")).SendKeys(password);
        }

       
        [When(@"user clicks the login button")]
        public void WhenUserClicksTheLoginButton()
        {
            driver.FindElement(By.Id("login")).Click();
        }
        
        [Then(@"the page should navigate to profile page")]
        public void ThenThePageShouldNavigateToProfilePage()
        {
            Thread.Sleep(1000);

            _specFlowOutputHelper.WriteLine(driver.Url);
            // Assert.True(driver.FindElement(By.XPath(".//div[@class='text-right col-md-5 col-sm-12']//button[@id='submit']")).Displayed);
            Assert.True(driver.Url == "https://demoqa.com/profile");
            driver.Quit();

        }

        [Then(@"the username field should show error")]
        public void ThenTheUsernameFieldShouldShowError()
        {
            Thread.Sleep(200);

            _specFlowOutputHelper.WriteLine(driver.FindElement(By.Id("userName")).GetCssValue("border-color"));
            Assert.True(driver.FindElement(By.Id("userName")).GetCssValue("border-color") == "rgb(220, 53, 69)");
            
            //String color = element.getCSSValue;
        }
     

        [Then(@"the password field should show error")]
        public void ThenThePasswordFieldShouldShowError()
        {
            Thread.Sleep(200);

            _specFlowOutputHelper.WriteLine(driver.FindElement(By.Id("password")).GetCssValue("border-color"));
            Assert.True(driver.FindElement(By.Id("password")).GetCssValue("border-color") == "rgb(220, 53, 69)");
            driver.Quit();
        }
        [Then(@"the page should display an error message")]
        public void ThenThePageShouldDisplayAnErrorMessage()
        {
            Thread.Sleep(500);
            Assert.True(driver.FindElement(By.Id("name")).Displayed);
            driver.Quit();
        }


    }
}
