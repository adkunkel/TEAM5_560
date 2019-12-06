using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FantasyData.Models;
namespace FantasyData.Controller
{
    class Controller
    {
        public Models.Player.PlayerInfo[] player_infos = new Models.Player.PlayerInfo[532];
        
        public void fillArray(string filepath)
        {
            StreamReader reader = new StreamReader(filepath);
            reader.ReadLine();
            int i = 0;
            while (!reader.EndOfStream)
            {
                string raw_player_info = reader.ReadLine();
                string[] raw_player_info_split = raw_player_info.Split('|');
                Player.QBRWTE.Position position = Player.QBRWTE.Position.QB;
                switch(raw_player_info_split[5])
                {
                    case "QB":
                        position = Player.QBRWTE.Position.QB;
                        break;
                    case "RB":
                        position = Player.QBRWTE.Position.RB;
                        break;
                    case "WR:":
                        position = Player.QBRWTE.Position.WR;
                        break;
                    case "TE":
                        position = Player.QBRWTE.Position.TE;
                        break;
                }

                Player.PlayerInfo player_info = new Player.PlayerInfo();
                player_info.Name = raw_player_info_split[0];
                player_info.Height = Convert.ToInt32(raw_player_info_split[1]);
                player_info.Weight = Convert.ToInt32(raw_player_info_split[2]);
                player_info.YearsPro = Convert.ToInt32(raw_player_info_split[3]);
                player_info.BirthDate = Convert.ToDateTime(raw_player_info_split[4]);
                player_info.Position = position;
                
                player_infos[i] = player_info;
                i++;
            }
        }

        /// <summary>
        /// You smell bad
        /// </summary>
        /// <param name="p"></param>
        public void InsertQB(Player p)
        {
 //           sql =
        }

    }
}
