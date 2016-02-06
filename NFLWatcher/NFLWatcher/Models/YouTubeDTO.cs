using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    abstract public class YouTubeDTO {
        public string Id { get; set; }
        public string Title { get; set; }
    }
    public class VideoDTO : YouTubeDTO { }
    public class ChannelDTO : YouTubeDTO { }
    public class PlayListDTO : YouTubeDTO { }
}
