using Anticaptcha_example.Api;
using Anticaptcha_example.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using RandomUserAgent;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using WindowsInput;
using WindowsInput.Native;

namespace WinParser.Tools
{
    internal static class Parser
    {
        private static IWebDriver _driver = null;
        static string _userAgent;
        public static void SetUserAgent()
        {
            _userAgent = RandomUa.RandomUserAgent;
        }
        
        public static void Init() 
        {
            ChromeOptions options = new ChromeOptions();
            SetUserAgent();

            options.AddArgument(string.Format("--user-agent={0}", _userAgent));
            //options.AddArgument("headless");

            _driver = new ChromeDriver(options)
            {
                Url = Setts.URL
            };
            string str = _driver.CurrentWindowHandle;
        }
        /// <summary>
        /// Получить элемент
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IWebElement GetElement(int type, string value) 
        {
            if (_driver == null)
                Init();

            IWebElement element = null;
            try 
            {
                switch (type)
                {
                    case 1:
                        element = _driver.FindElement(By.CssSelector(value));
                        break;
                    case 2:
                        element = _driver.FindElement(By.XPath(value));
                        break;
                    case 3:
                        element = _driver.FindElement(By.TagName(value));
                        break;
                }
            }
            catch (Exception ex )
            {
                element = null;
                return element;
            }

            return element;
        }
        public static IWebElement GetElement(int type, string value, IWebElement subElement)
        {
            if (subElement == null)
                return GetElement(type, value);

            IWebElement element = null;
            try
            {
                switch (type)
                {
                    case 1:
                        element = subElement.FindElement(By.CssSelector(value));
                        break;
                    case 2:
                        element = subElement.FindElement(By.XPath(value));
                        break;
                    case 3:
                        element = subElement.FindElement(By.TagName(value));
                        break;
                }
            }
            catch (Exception ex)
            {
                element = null;
                return element;
            }

            return element;
        }
        /// <summary>
        /// Получить список элементов
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> GetElements(int type, string value)
        {
            if (_driver == null)
                Init();

            ReadOnlyCollection<IWebElement> elements = null;
            try
            {
                switch (type)
                {
                    case 1:
                        elements = _driver.FindElements(By.CssSelector(value));
                        break;
                    case 2:
                        elements = _driver.FindElements(By.XPath(value));
                        break;
                    case 3:
                        elements = _driver.FindElements(By.TagName(value));
                        break;

                }
            }
            catch (Exception ex)
            {
                elements = null;
                return elements;
            }

            return elements;
        }
        public static ReadOnlyCollection<IWebElement> GetElements(int type, string value, IWebElement subElement)
        {
            if (subElement == null)
                return GetElements(type, value);

            ReadOnlyCollection<IWebElement> elements = null;
            try
            {
                switch (type)
                {
                    case 1:
                        elements = subElement.FindElements(By.CssSelector(value));
                        break;
                    case 2:
                        elements = subElement.FindElements(By.XPath(value));
                        break;
                    case 3:
                        elements = subElement.FindElements(By.TagName(value));
                        break;
                }
            }
            catch (Exception ex)
            {
                elements = null;
                return elements;
            }

            return elements;
        }

        public static void Close() 
        {
            _driver.Quit();
        }

        public static void ClearSession() 
        {
            try
            {
                Setts.SetWaitKey();
                (_driver as IJavaScriptExecutor).ExecuteScript("sessionStorage.clear();");
                (_driver as IJavaScriptExecutor).ExecuteScript("localStorage.clear();");
            }
            catch (Exception ex){ }
        }
        /// <summary>
        /// Серви распознования капчи
        /// </summary>
        /// <param name="path"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string GetCapcha(string path, out string error) 
        {
            error = string.Empty;
            string result = string.Empty;
            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = "7482df01617c712f86b4e647b4acc826",
                FilePath = path,
                SoftId = 0
            };

            if (!api.CreateTask())
                error = string.Format(@"API v2 send failed. {0}", api.ErrorMessage);
            else if (!api.WaitForResult())
                error = string.Format(@"Could not solve the captcha. {0}", api.ErrorMessage);
            else
                result = api.GetTaskSolution().Text;

            return result;
        }

        public static string CopyLink(string url) 
        {
            _driver.SwitchTo().NewWindow(WindowType.Tab);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.Navigate().GoToUrl(url);
            _driver.SwitchTo().Window(_driver.WindowHandles.First());

            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            
            //File.Move(downloadsPath + @"\captcha", downloadsPath + @"\captcha.png");
            
            return downloadsPath + @"\captcha";
        }

        public static void RefreshPage() 
        {
            _driver.Navigate().GoToUrl(Setts.URL);
        }
    }
}
