using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyData.Models
{
    class NFL
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }

        public class TeamStats
        {
            public string Record { get; set; }
            public double PointsScored { get; set; }
            public double PointsAllowed { get; set; }
        }
    }
}
