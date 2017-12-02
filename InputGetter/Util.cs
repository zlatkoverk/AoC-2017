using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;

    public class Util
    {
        /// <summary>
        /// Base url for this year's Advent of code.
        /// </summary>
        private const string BaseUrl = "http://www.adventofcode.com/2017";

        /// <summary>
        /// Method which returns input for given day as string.
        /// </summary>
        /// <param name="day">day</param>
        /// <returns>input for given day</returns>
        public static string GetInputForDay(int day)
        {
            string url = $"{BaseUrl}/day/{day}/input";
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(@url);
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(new Cookie("session", "53616c7465645f5f1ef099c285eca8c7c001f86749b73ec1a4f50018ce03d80069940bb8498ce74a811aec381fc660bf", "/", ".adventofcode.com"));
            


        using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            using (Stream stream = resp.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd().Trim();
            }
        }
    }
