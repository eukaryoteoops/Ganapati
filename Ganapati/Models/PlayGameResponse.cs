using System.Collections.Generic;

namespace Ganapati.Models
{
    public class PlayGameResponse : GamePageResponse
    {
        public List<int> PlayerPoint { get; set; }
        public List<int> HostPoint { get; set; }

    }
}
