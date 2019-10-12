using System.Collections.Generic;

namespace ResolutionTester.CoreConsoleApplication
{
    public class Resolutions
    {
        public static IEnumerable<string> GetResolutions()
        {
            return new[]
            {
                "375x667",
                "375x812",
                "414x896",
                "1920x1080",
                "768x1024",
                "414x736",
                "360x640",
                "360x740",
                "412x846",
                "1366x768",
            };
        }
    }
}
