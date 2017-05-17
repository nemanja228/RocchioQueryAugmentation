using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;

namespace RocchioQueryAugmentation
{
    public class WebSearcher
    {
        private static string USER_AGENT = "RocchioQueryAugmentation";

        private static int RESULTS_PER_PAGE = 10;

        private static int MAX_PAGES = 3;

        private static readonly Encoding DEFAULT_ENCODING = Encoding.UTF8;

        private static string URL_START = "<h3 class=\"r\"><a href=\"/url?q=";
        private static string URL_END = "&";
        private static string TITLE_START = ">";
        private static string TITLE_END = "</a>";
        private static string SUMMARY_START = "<span class=\"st\">";
        private static string SUMMARY_END = "</span>";
      


        public WebSearcher()
        {

        }

        private string GetHtmlFromUri(string url)
        {
            string htmlContent = String.Empty;
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            request.Method = WebRequestMethods.Http.Get;
            request.UserAgent = USER_AGENT;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                htmlContent = reader.ReadToEnd();
            }

            return htmlContent;
        }

        public List<Document> GetTopSearchResults(string query, int num)
        {
            List<Document> searchResults = new List<Document>();
            int startFromPage = 0;

            while(searchResults.Count < num)
            {
                string url = String.Format("https://www.google.com/search?q={0}&start={1}&num={2}", HttpUtility.UrlEncode(query), startFromPage * RESULTS_PER_PAGE, RESULTS_PER_PAGE);
                string htmlContent = GetHtmlFromUri(url);
                List<Document> tmpResults = GetSearchResultsFromHtml(htmlContent);
                searchResults.AddRange(tmpResults);
                startFromPage++;
            }

            if(searchResults.Count > num)
            {
                searchResults.RemoveRange(num, searchResults.Count - num);
            }

            return searchResults;
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

        public string GetBodyContentFromUrl(string url)
        {
            string html = GetHtmlFromUri(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            string content = HttpUtility.HtmlDecode(doc.DocumentNode.SelectSingleNode("//body").InnerHtml);
            content = Regex.Replace(content, "<[^>]*(>|$)", String.Empty);
            content = Regex.Replace(content, "[\\s\\r\\n]+", " ");
            //content = Regex.Replace(content, "{.*}", String.Empty);
            content.Trim();
            return content;
        }
    }
}
