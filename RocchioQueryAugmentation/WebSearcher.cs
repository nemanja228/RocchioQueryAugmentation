using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using Supremes.Parsers;
using Supremes;
using System.Diagnostics;

namespace RocchioQueryAugmentation
{
    public class WebSearcher
    {
        private static string USER_AGENT = "RocchioQuery";
        private static int RESULTS_PER_PAGE = 10;
        private static readonly Encoding DEFAULT_ENCODING = Encoding.UTF8;
        private static int TIMEOUT_FACTOR = 10;

        private static string URL_START = "<h3 class=\"r\"><a href=\"/url?q=";
        private static string URL_END = "&";
        private static string TITLE_START = ">";
        private static string TITLE_END = "</a>";
        private static string SUMMARY_START = "<span class=\"st\">";
        private static string SUMMARY_END = "</span>";
      


        public WebSearcher()
        {

        }

        public List<Document> GetTopSearchResults(string query, int num)
        {
            List<Document> searchResults = new List<Document>();
            int startFromPage = 0;
            int count = 0;

            while(searchResults.Count < num && count < (num * TIMEOUT_FACTOR))
            {
                count++;
                string url = String.Format("http://www.google.com/search?q={0}&start={1}&num={2}&hl=en&gl=en", HttpUtility.UrlEncode(query), startFromPage * RESULTS_PER_PAGE, RESULTS_PER_PAGE);
                bool success;
                string htmlContent = GetHtmlFromUri(url, out success);
                if (!success)
                    continue;
                List<Document> tmpResults = GetSearchResultsFromHtml(htmlContent);
                searchResults.AddRange(tmpResults);
                startFromPage++;
            }

            if(searchResults.Count > num)
            {
                searchResults.RemoveRange(num, searchResults.Count - num);
            }

            for (int i = 0; i < searchResults.Count; i++)
            {
                searchResults[i].Id = i;
            }

            return searchResults;
        }

        public string GetBodyContentFromUrl(string url)
        {
            bool success;
            string html = GetHtmlFromUri(url, out success);
            if (success)
                return Dcsoup.Parse(html).Body.Text;
            else
                return null;
        }

        private string GetHtmlFromUri(string url, out bool success)
        {
            string htmlContent = null;
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            request.Method = WebRequestMethods.Http.Get;
            request.UserAgent = USER_AGENT;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    htmlContent = reader.ReadToEnd();
                }
            }
            catch(Exception exc)
            {
                Debug.Print(exc.Message);
            }

            if (htmlContent == null)
            {
                success = false;
                return String.Empty;
            }
            else
            {
                success = true;
                return htmlContent;
            }

        }

        private List<Document> GetSearchResultsFromHtml(string html)
        {
            List<Document> searchResults = new List<Document>();

            int index = 0;

            while ((index = html.IndexOf(URL_START, index)) != -1)
            {
                index = index + URL_START.Length;
                int urlStart = index;
                index = html.IndexOf(URL_END, index);
                int urlEnd = index;

                
                index = html.IndexOf(TITLE_START, index);
                index = index + TITLE_START.Length;
                int titleStart = index;
                index = html.IndexOf(TITLE_END, index);
                int titleEnd = index;

                index = html.IndexOf(SUMMARY_START, index);
                index = index + SUMMARY_START.Length;
                int summaryStart = index;
                index = html.IndexOf(SUMMARY_END, index);
                int summaryEnd = index;

                string url = html.Substring(urlStart, urlEnd - urlStart);
                string title = html.Substring(titleStart, titleEnd - titleStart).Replace("<b>", "").Replace("</b>", "");
                string summary = html.Substring(summaryStart, summaryEnd - summaryStart).Replace("<em>", "").Replace("</em>", "").Replace("<b>", "").Replace("</b>", "").Replace("<br>\n", "");

                url = HttpUtility.HtmlDecode(url);
                title = HttpUtility.HtmlDecode(title);
                summary = HttpUtility.HtmlDecode(summary);

                searchResults.Add(new Document(title, url, summary));
            }

            return searchResults;
        }
    }
}
