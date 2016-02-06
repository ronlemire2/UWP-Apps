using FeedReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Syndication;

namespace FeedReader.Services {
    public class FeedService : IFeedService {
        public async virtual Task<List<Feed>> GetFeedsAsync(string link) {
            List<Feed> feeds = new List<Feed>();

            try {
                // http://stackoverflow.com/questions/21500336/how-to-get-file-in-winrt-from-project-path
                var uri = new System.Uri(link);
                var feedsJsonFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
                var feedsJsonData = await Windows.Storage.FileIO.ReadTextAsync(feedsJsonFile);

                JsonObject jsonObject = JsonObject.Parse(feedsJsonData);
                JsonArray jsonArray = jsonObject["Feeds"].GetArray();

                Feed feed;
                foreach (JsonValue feedValue in jsonArray) {
                    JsonObject feedObject = feedValue.GetObject();
                    feed = new Feed {
                        FeedName = feedObject["Name"].GetString(),
                        Link = feedObject["Link"].GetString(),
                        LastUpdated = feedObject["LastUpdated"].GetString()
                    };
                    feeds.Add(feed);
                }
            }
            catch (Exception x) {
                string msg = x.Message;
            }

            return feeds.OrderBy(f => f.FeedName).ToList();
        }

        public async Task<FeedData> GetFeedAsync(string link) {
            Windows.Web.Syndication.SyndicationClient client = new SyndicationClient();
            Uri feedUri = new Uri(link);

            try {
                SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);

                // This code is executed after RetrieveFeedAsync returns the SyndicationFeed.
                // Process the feed and copy the data you want into the FeedData and FeedItem classes.
                FeedData feedData = new FeedData();

                if (feed.Title != null && feed.Title.Text != null) {
                    feedData.Title = feed.Title.Text;
                }
                if (feed.Subtitle != null && feed.Subtitle.Text != null) {
                    feedData.Description = feed.Subtitle.Text;
                }
                if (feed.Items != null && feed.Items.Count > 0) {
                    // Use the date of the latest post as the last updated date.
                    feedData.PubDate = feed.Items[0].PublishedDate.DateTime;

                    foreach (SyndicationItem item in feed.Items) {
                        FeedItem feedItem = new FeedItem();
                        if (item.Title != null && item.Title.Text != null) {
                            feedItem.Title = item.Title.Text;
                        }
                        if (item.PublishedDate != null) {
                            feedItem.PubDate = item.PublishedDate.DateTime;
                        }
                        if (item.Authors != null && item.Authors.Count > 0) {
                            feedItem.Author = item.Authors[0].Name.ToString();
                        }
                        // Handle the differences between RSS and Atom feeds.
                        if (feed.SourceFormat == SyndicationFormat.Atom10) {
                            if (item.Content != null && item.Content.Text != null) {
                                feedItem.Content = item.Content.Text;
                            }
                            if (item.Id != null) {
                                feedItem.Link = new Uri(item.Id);
                            }
                        }
                        else if (feed.SourceFormat == SyndicationFormat.Rss20) {
                            if (item.Summary != null && item.Summary.Text != null) {
                                feedItem.Content = item.Summary.Text;
                            }
                            if (item.Links != null && item.Links.Count > 0) {
                                feedItem.Link = item.Links[0].Uri;
                            }
                        }
                        feedData.Items.Add(feedItem);
                    }
                }
                return feedData;
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
