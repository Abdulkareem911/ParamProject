using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers; 
using System;
using System.Security.Policy;

using System.Threading;
namespace ConsoleApp1
{
    internal class Program
    {
        static ChromeOptions UseBraveBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";

            // Use existing Brave user profile
            options.AddArgument(@"--user-data-dir=C:\Users\aaall\AppData\Local\BraveSoftware\Brave-Browser\User Data");
            options.AddArgument("--profile-directory=Default");
            
            // Use 'Default' profile
            return options;
        }

        static WebDriverWait StopTheBrowserForSeconds (int Seconds, IWebDriver driver)
        {
          return  new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds));
        }

        static void WaitForPageToLoadCompletly(IWebDriver driver, WebDriverWait wait)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // WaitForPageLoad
            wait.Until(drv => js.ExecuteScript("return document.readyState").Equals("complete"));
        }

        static void TestMainElementsVisibility(IWebDriver driver)
        {
                
            try
            {
                WebDriverWait wait = StopTheBrowserForSeconds(50,driver);

                WaitForPageToLoadCompletly(driver, wait);

               
                IWebElement OpportunityStatus = wait.Until(drv => drv.FindElement(By.CssSelector("#widget_67517e72513c3b2afa79ec72 > div > div > div > div > div.hl-card-header > div > div.truncate.mr-2 > div")));
                IWebElement OpportunityValue  = wait.Until(drv => drv.FindElement(By.CssSelector("#widget_67517e72513c3bd3fb79ec73 > div > div > div > div > div.hl-card-header > div > div.truncate.mr-2 > div")));
                IWebElement ConversionRate    = wait.Until(drv => drv.FindElement(By.CssSelector("#widget_67517e72513c3b153579ec74 > div > div > div > div > div.hl-card-header > div > div.truncate.mr-2 > div")));

                Console.WriteLine("\n\n\nAll main dashboard elements are visible.");

            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: Element not found or not interactable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void TestSearchBarClicjkButtons (IWebDriver driver)
        {
           
            try
            {
                WebDriverWait wait = StopTheBrowserForSeconds(50, driver);

                WaitForPageToLoadCompletly(driver, wait);

                IWebElement SideNavigationButton = wait.Until(drv => drv.FindElement(By.CssSelector("#globalSearchOpener > div > div.flex.flex-row.justify-start.items-center")));

                SideNavigationButton.Click();

                Console.WriteLine("\n\n\nSide navigation button clicked successfully.\n\n\n");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: Element not found or not interactable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void GoToURL(IWebDriver driver, string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        static void TestStartHelpGuidButton(IWebDriver driver)
        {
            try
            {


                WebDriverWait wait = StopTheBrowserForSeconds(50, driver);

                WaitForPageToLoadCompletly(driver, wait);



                IWebElement StartHelpGuidButton = wait.Until(drv => drv.FindElement(By.CssSelector("#start-help-guide > div > div > img")));

                    

                StartHelpGuidButton.Click();
                Console.WriteLine("\n\n\n Start Help Guid button clicked successfully.\n\n\n");
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: Element not found or not interactable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        } 
        
        static void TestSettingsButton(IWebDriver driver)
        {
            try
            {


                WebDriverWait wait = StopTheBrowserForSeconds(50, driver);

                WaitForPageToLoadCompletly(driver, wait);



                IWebElement SettingsButton = wait.Until(drv => drv.FindElement(By.CssSelector("#sb_settings > img")));


                SettingsButton.Click();
                Console.WriteLine("\n\n\n Settings Button clicked successfully.\n\n\n");
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: Element not found or not interactable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void TestCalenderButton(IWebDriver driver)
        {
            try
            {


                WebDriverWait wait = StopTheBrowserForSeconds(50, driver);

                WaitForPageToLoadCompletly(driver, wait);



                IWebElement CalenderButton = wait.Until(drv => drv.FindElement(By.CssSelector("#sb_calendars > img")));


                CalenderButton.Click();
                Console.WriteLine("\n\n\n Calender Button clicked successfully.\n\n\n");
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: Element not found or not interactable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }




































       public static void Main(string[] args)
       {

            IWebDriver driver = new ChromeDriver(UseBraveBrowser());

            GoToURL(driver,"https://platform.hoopai.com");

            Console.WriteLine("\n\n\nNavigated to the page STARTING TEST... \n\n\n");

            //TestMainElementsVisibility(driver);

            //TestSideNavigationButtons(driver);

            TestStartHelpGuidButton(driver);

            //TestCalenderButton(driver);

            //TestSettingsButton(driver);













        }
    }
}
