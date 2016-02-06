using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubePlayer.Models {
    public partial class YouTubeSearchFilter {
        public int Id { get; set; }
        public string SearchTerm { get; set; }
        public int MaxResults { get; set; }
        public string IdKind { get; set; }
    }
}
