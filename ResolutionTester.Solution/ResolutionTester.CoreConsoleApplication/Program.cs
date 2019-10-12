using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ResolutionTester.CoreConsoleApplication
{
    class Program
    {
        const string url = "https://leasing.com";

        static void Main(string[] args)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("hide-scrollbars");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {
                var resolutions = Resolutions.GetResolutions();

                foreach (var resolution in resolutions)
                {
                    Console.WriteLine($"Processing {resolution}");

                    var dimensions = resolution.Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);

                    // Change window dimensions
                    driver.Manage().Window.Size = new Size(int.Parse(dimensions[0]), int.Parse(dimensions[1]));

                    // Navigate to page
                    driver.Navigate().GoToUrl(url);

                    // Generate screenshot of each page
                    Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();

                    var fileName = $"{resolution}.png";

                    //Save locally
                    var path = Path.Combine(@"c:\tests\", fileName);
                    image.SaveAsFile(path, ScreenshotImageFormat.Png);
                }
            }

        }
    }
}
