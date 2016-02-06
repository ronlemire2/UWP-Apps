using FeedReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Services {
    public interface IComicsService : IFeedService {
        IEnumerable<object> GetFeedGroups(List<Feed> feeds);
    }
}
