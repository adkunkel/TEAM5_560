using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyData.Models
{
    class Player
    {
        public class Kicker
        {
            public int KickerStatsID { get; set; }
            public string PlayerID { get; set; }
            public string XPMade { get; set; }
            public string XPMissed { get; set; }
            public string FGGD { get; set; }
            public string FGNG { get; set; }
            public string GameID { get; set; }
            public string ByeWeek { get; set; }
        }

        public class Defense
        {
            public string DefenseStatsID { get; set; }
            public string PlayerID { get; set; }
            public string PassYardsAllowed { get; set; }
            public string RushYardsAllowed { get; set; }
            public string Touchdowns { get; set; }
            public string Safeties { get; set; }
            public string Interceptions { get; set; }
            public string Fumbles { get; set; }
            public string GameID { get; set; }
            public string ByeWeek { get; set; }
        }

        public class QBRWTE
        {
            public string PlayerStatsID { get; set; }
            public string PlayerID { get; set; }
            public string PassYard { get; set; }
            public string RushYard { get; set; }
            public string RecievingYards { get; set; }
            public string Receptions { get; set; }
            public string Touchdowns { get; set; }
            public string Interceptions { get; set; }
            public string Fumbles { get; set; }
            public string GameID { get; set; }
            public string ByeWeek { get; set; }
            public enum Position { QB, RB, WR, TE}
        }
    }
}
