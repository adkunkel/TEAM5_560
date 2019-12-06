using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyData.Models
{
    class NFL
    {
        
        public string[] Teams = {"New England, Patriots", "Dallas, Cowboys", "San Francisco, 49ers", "Seattle, Seahawks", "Baltimore, Ravens", "Philadelphia, Eagles", "Green Bay, Packers", "Minnesota, Vikings", "Pittsburgh, Steelers", "Buffalo Bills", "Chicago, Bears", "New Orleans, Saints", "OakLand, Raiders", "Cleveland, Browns", "Kansas City, Chiefs", "New York, Giants", "Houston,Texans", "Detroit, Lions", "Miami, Dolphins", "Denver, Broncos", "Los Angeles, Rams", "Washington, Redskins", "Arizona, Cardinals", "Carolina, Panthers", "Atlanta, Falcons", "New York, Jets", "Cincinnati, Bengals", "Tennessee, Titans", "Indianapolis, Colts", "Los Angles, Chargers", "Tampa Bay, Buccaneers", "Jacksonville, Jaguars"}; 

        public class TeamStats
        {
            public string Record { get; set; }
            public double PointsScored { get; set; }
            public double PointsAllowed { get; set; }
        }
    }
    
}
