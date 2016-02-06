﻿using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubePlayer.Models;

namespace YouTubePlayer.Services {
    public static class MyYouTubeService {
        public static async Task<List<YouTubeDTO>> SearchYouTube(string searchTerm) {
            List<YouTubeDTO> DTOs = null;

            try {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer() {
                    ApiKey = "<ApiKey goes here>",
                    ApplicationName = "YouTubePlayer"
                });

                string youTubeSearchTerm = searchTerm;
                int maxResults = 25;
                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = youTubeSearchTerm;
                searchListRequest.MaxResults = maxResults;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = await searchListRequest.ExecuteAsync();

                YouTubeDTO y = new VideoDTO();

                DTOs = new List<YouTubeDTO>();

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items) {
                    if (searchResult.Id.Kind == "youtube#video") {
                        DTOs.Add(new VideoDTO { Title = searchResult.Snippet.Title, Id = searchResult.Id.VideoId });
                    }
                }

                // http://stackoverflow.com/questions/3163922/sort-a-custom-class-listt
                //DTOs.Sort((a, b) => a.Title.CompareTo(b.Title));
                //videoDTOs.Sort(delegate(VideoDTO v1, VideoDTO v2) { return v1.Title.CompareTo(v2.Title); });

            }
            catch (Exception x) {
                string msg = x.Message;
            }

            return DTOs;
        }
    }
}
