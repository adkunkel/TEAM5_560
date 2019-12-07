using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyData.Models
{
    public enum Position { QB, RB, WR, TE }
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
            
            public string PassYard { get; set; }
            public string RushYard { get; set; }
            public string ReceivingYards { get; set; }
            public string Receptions { get; set; }
            public string Touchdowns { get; set; }
            public string Interceptions { get; set; }
            public string Fumbles { get; set; }
            public string GameID { get; set; }
            public string ByeWeek { get; set; }
            
        }

        public class TeamPlayer
        {
            // this class may need to encap all other classes
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class PlayerInfo
        {
            // this class may need to encap all other classses
            public int PlayerInfoID { get; set; }
            public string Name { get; set; }
            public string Status { get; set; } // may want to do enum
            public int Height { get; set; }
            public int Weight { get; set; }
            public int YearsPro { get; set; }
            public DateTime BirthDate { get; set; }
            public Position Position { get; set; }
            public List<QBRWTE> Stats {get; set;}
        }

       
    } 
}
