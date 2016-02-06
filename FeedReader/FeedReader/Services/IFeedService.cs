using FeedReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Services {
    public interface IFeedService {
        Task<List<Feed>> GetFeedsAsync(string link);
        Task<FeedData> GetFeedAsync(string link);
    }
}
