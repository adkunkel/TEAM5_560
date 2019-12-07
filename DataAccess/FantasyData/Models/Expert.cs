using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyData.Models
{
    class Expert
    {
        public int RankingID { get; set; }
        public int PlayerID { get; set; }
        public string OverallRank { get; set; }
        public string PosistionRank { get; set; }
        public string Week { get; set; }
    }
}
