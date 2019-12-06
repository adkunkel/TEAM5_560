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

        public List<Player.PlayerInfo> QuarterBacks = new Player.PlayerInfo[100];
        public List<Player.PlayerInfo> RunningBacks = new Player.PlayerInfo[100];
        public List<Player.PlayerInfo> TeightEnds = new Player.PlayerInfo[75];
        public List<Player.PlayerInfo> WideRecivers  = new Player.PlayerInfo[200];
        
        public static void SortPlayerInfo()
        {
            foreach(Player.PlayerInfo p in player_infos)
            {
                switch(p.Position)
                {
                    case "QB":
                        QuarterBacks.Add(p);
                        break;
                    case "RB":
                        RunningBacks.Add(p);
                        break;
                    case "WR":
                        WideRecivers.Add(p);
                        break;
                    case "TE":
                        TeightEnds.Add(p);
                        break;

                }
            }
            
        }
        public void fillArray(string filepath)
        {
            Models.
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

        public Models.Player.PlayerInfo[] QuarterBackList( string file)
        {
        
            using(StreamReader sr = new StreamReader())
            {
                sr.ReadLine();
                for(int i = 0; i < 100; i++)
                {
                    for(int k = 0; k < 100; i++)
                    {
                        Player.QBRWTE p = new Player.QBRWTE();
                        string line = sr.ReadLine();
                        string[] pLine = line.Split('|');
                        p.PassYard = pLine[0];
                        p.RushYard = pLine[1];
                        p.ReceivingYards = pLine[2];
                        p.Receptions = pLine[3];
                        p.Touchdowns = pLine[4];
                        p.Interceptions = pLine[5];
                        p.Fumbles = pLine[6];
                        QuarterBacks[k].Stats.Add(p);
                                          
                    }
                }
            }
            return QuarterBacks;
        }
        
        public Models.Player.PlayerInfo[] RunningBackList( string file)
        {
        
            using(StreamReader sr = new StreamReader())
            {
                sr.ReadLine();
                for(int i = 0; i < 100; i++)
                {
                    for(int k = 0; k < 100; i++)
                    {
                        Player.QBRWTE p = new Player.QBRWTE();
                        string line = sr.ReadLine();
                        string[] pLine = line.Split('|');
                        p.PassYard = pLine[0];
                        p.RushYard = pLine[1];
                        p.ReceivingYards = pLine[2];
                        p.Receptions = pLine[3];
                        p.Touchdowns = pLine[4];
                        p.Interceptions = pLine[5];
                        p.Fumbles = pLine[6];
                        RunningBacks[k].Stats.Add(p);
                                           
                    }
                }
            }
            return RunningBacks;
        }

         public Models.Player.PlayerInfo[] TieghtEndsList(string file)
        {
        
            using(StreamReader sr = new StreamReader())
            {
                sr.ReadLine();
                for(int i = 0; i < 75; i++)
                {
                    for(int k = 0; k < 75; i++)
                    {
                        Player.QBRWTE p = new Player.QBRWTE();
                        string line = sr.ReadLine();
                        string[] pLine = line.Split('|');
                        p.PassYard = pLine[0];
                        p.RushYard = pLine[1];
                        p.ReceivingYards = pLine[2];
                        p.Receptions = pLine[3];
                        p.Touchdowns = pLine[4];
                        p.Interceptions = pLine[5];
                        p.Fumbles = pLine[6];
                        TieghtEnds[k].Stats.Add(p);
                                           
                    }
                }
            }
            return RunningBacks;
        }

        public Models.Player.PlayerInfo[] WideRecieversList(string file)
        {
        
            using(StreamReader sr = new StreamReader())
            {
                sr.ReadLine();
                for(int i = 0; i < 200; i++)
                {
                    for(int k = 0; k < 200; i++)
                    {
                        Player.QBRWTE p = new Player.QBRWTE();
                        string line = sr.ReadLine();
                        string[] pLine = line.Split('|');
                        p.PassYard = pLine[0];
                        p.RushYard = pLine[1];
                        p.ReceivingYards = pLine[2];
                        p.Receptions = pLine[3];
                        p.Touchdowns = pLine[4];
                        p.Interceptions = pLine[5];
                        p.Fumbles = pLine[6];
                        WideRecievers[k].Stats.Add(p);
                                           
                    }
                }
            }
            return RunningBacks;
        }

    }
}
