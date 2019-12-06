using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FantasyData.Models;

namespace FantasyData.Controller
{
    class RemoveDecimalStats
    {
        public void removeDecimals(string filepath)
        {
            StreamReader reader = new StreamReader(filepath);
            reader.ReadLine();
            int i = 0;
            while (!reader.EndOfStream)
            {
                string raw_player_info = reader.ReadLine();
                string[] raw_player_info_split = raw_player_info.Split('|');
                Player.QBRWTE.Position position = Player.QBRWTE.Position.QB;
                switch (raw_player_info_split[5])
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

                i++;
            }
        }
    }
}
