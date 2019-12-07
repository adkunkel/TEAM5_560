using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyData.Models
{
    class Games
    {
        public int GameID { get; set; }
        public int HomeTeamID { get; set; }
        public int VisitorTeamID { get; set; }
        public string Week { get; set; }
        public Season _Season { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }

        public class TeamGame
        {
            public int TeamGameID { get; set; }
            public int TeamID { get; set; }
            public bool IsHomeTeam { get; set; }
        }

        public class Season
        {
            public int SeasonID { get; set; }
            public string year { get; set; }

        }
    }
}
