using FeedReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace FeedReader.Services {
    public class ComicsService : FeedService, IComicsService {

        public override async Task<List<Feed>> GetFeedsAsync(string link) {
            List<Feed> feeds = null;
            string html = string.Empty;

            html = await WebPageToString(link);
            feeds = ParseWebPageForComicsLinks(html);

            return feeds;
        }

        public IEnumerable<object> GetFeedGroups(List<Feed> feeds) {
            IEnumerable<object> feedsByLetter;

            feedsByLetter = feeds
                .OrderBy(f => f.FeedName)
                .GroupBy(f => f.FeedName[0])
                .OrderBy(g => g.Key)
                .Select(g => g);

            return feedsByLetter;
        }

        private async Task<string> WebPageToString(string link) {
            HttpClient httpClient = new HttpClient();
            Uri requestUri = new Uri(link);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = string.Empty;

            try {
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex) {
                httpResponseBody = string.Format("Error: {0}  Message: ", ex.HResult.ToString("X"), ex.Message);
            }

            return httpResponseBody;
        }

        private List<Feed> ParseWebPageForComicsLinks(string html) {
            List<Feed> feeds = new List<Feed>();

            int pos1 = 0;   // start of link
            int pos2 = 0;   // end of link
            int pos3 = 0;   // start of age
            int pos4 = 0;   // end of age
            string link = string.Empty;
            string name = string.Empty;
            string savelink = string.Empty;
            string lastUpdated = string.Empty;
            int rep = 1;

            pos1 = html.IndexOf(@"/Feed");                  // search for start of link
            while (pos1 != -1) {
                pos2 = html.IndexOf("\"", pos1);            // search for ending quote mark
                link = "http://www.comicsyndicate.org" + html.Substring(pos1, pos2 - pos1);
                name = link.Substring(35);

                if (rep == 3) {
                    pos3 = html.IndexOf(@">", pos2);
                    pos4 = html.IndexOf(@"</a>", pos2);
                    lastUpdated = html.Substring((pos3 + 1), (pos4 - 1) - (pos3 + 1)).Trim();
                    rep = 1;
                }
                else {
                    rep++;
                }

                if (link != savelink) {
                    feeds.Add(new Feed {
                        FeedName = name.Replace("%20", " ").Replace("%40", " ").Replace("%26", " ").Replace("%39", " ").Replace("%2C", " ")
                        ,
                        Link = link,
                        LastUpdated = lastUpdated
                    });
                    savelink = link;
                }

                pos1 = html.IndexOf(@"/Feed", pos2 + 1);
            }

            return feeds;
        }

        /*
        Algorithm notes:
        1) Search for /Feed - pos1
        2) Search for \ - pos2
        3) Substring from pos1 to pos2
        4) Concatenate http?//www.comicsyndicate.org to 3 - this gets whole link
        5) Substring 4 from start+35 to end - this gets name
        6) Replace %20 with space in name
        7) Replace %40 with space in name
        8) Replace %26 with space in name
        9) Replace %39 with space in name
        10) Replace %2C with space in name

        Example:
        3) /Feed/1977%20The%20comic\
        4) http://www.comicsyndicate.org/Feed/1977%20The%20comic - link
        5) 1977%20The%20comic - name
        10) 1977 The comic

        Each link/name repeats 3 times so skip occurrence 2 and 3

        After the 3rd repetition search for LastUpdated:
        1) Search for >
        2) Search for </a>
        3) Substring from start+1 to end-1
        4) Trim from both ends
        
        */
    }
}
