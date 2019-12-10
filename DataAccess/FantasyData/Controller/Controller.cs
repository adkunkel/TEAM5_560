using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FantasyData.Models;
namespace FantasyData.Controller
{
    public class Controller
    {

        public string[] Teams = { "New England Patriots", "Dallas Cowboys", "San Francisco 49ers", "Seattle Seahawks", "Baltimore Ravens", "Philadelphia Eagles", "Green Bay Packers", "Minnesota Vikings", "Pittsburgh Steelers", "Buffalo Bills", "Chicago Bears", "New Orleans Saints", "OakLand Raiders", "Cleveland Browns", "Kansas City, Chiefs", "New York Giants", "Houston Texans", "Detroit Lions", "Miami Dolphins", "Denver Broncos", "Los Angeles Rams", "Washington, Redskins", "Arizona Cardinals", "Carolina Panthers", "Atlanta Falcons", "New York, Jets", "Cincinnati Bengals", "Tennessee Titans", "Indianapolis Colts", "Los Angles Chargers", "Tampa Bay Buccaneers", "Jacksonville Jaguars" };

        public List<Player.PlayerInfo> player_infos = new List<Player.PlayerInfo>();

        public List<Player.PlayerInfo> QuarterBacks = new List<Player.PlayerInfo>(75);
        public List<Player.PlayerInfo> RunningBacks = new List<Player.PlayerInfo>(100);
        public List<Player.PlayerInfo> TightEnds = new List<Player.PlayerInfo>(75);
        public List<Player.PlayerInfo> WideReceivers  = new List<Player.PlayerInfo>(200);
        public List<Player.PlayerInfo> Kickers = new List<Player.PlayerInfo>(50);
        public List<Player.PlayerInfo> Defense = new List<Player.PlayerInfo>(32);
        
        public void SortPlayerInfo()
        {
            foreach(Player.PlayerInfo p in player_infos)
            {
                switch(p.Position)
                {
                    case Position.QB:
                        QuarterBacks.Add(p);
                        break;
                    case Position.RB:
                        RunningBacks.Add(p);
                        break;
                    case Position.WR:
                        WideReceivers.Add(p);
                        break;
                    case Position.TE:
                        TightEnds.Add(p);
                        break;
                    case Position.K:
                        Kickers.Add(p);
                        break;
                    default:
                        break;
                }
            }
        }

        public void FillPlayerInfoArray(string filepath)
        {
            StreamReader reader = new StreamReader(filepath);
            reader.ReadLine();
            int i = 0;
            while (!reader.EndOfStream)
            {
                string raw_player_info = reader.ReadLine();
                string[] raw_player_info_split = raw_player_info.Split('|');
                Position position = Position.N;
                switch(raw_player_info_split[5])
                {
                    case "QB":
                        position = Position.QB;
                        break;
                    case "RB":
                        position = Position.RB;
                        break;
                    case "WR":
                        position = Position.WR;
                        break;
                    case "TE":
                        position = Position.TE;
                        break;
                    case "K":
                        position = Position.K;
                        break;
                    default:
                        position = Position.N;
                        break;
                }
                if (position != Position.N)
                {
                    Player.PlayerInfo player_info = new Player.PlayerInfo();
                    player_info.Name = raw_player_info_split[0];
                    player_info.Height = Convert.ToInt32(raw_player_info_split[1]);
                    player_info.Weight = Convert.ToInt32(raw_player_info_split[2]);
                    player_info.YearsPro = Convert.ToInt32(raw_player_info_split[3]);
                    player_info.BirthDate = Convert.ToDateTime(raw_player_info_split[4]);
                    player_info.Position = position;

                    player_infos.Add(player_info);
                    i++;
                }
            }
        }

        public void QuarterBackList(string file)
        {
            using(StreamReader sr = new StreamReader(file))
            {
                sr.ReadLine();
                for(int i = 0; i < 16; i++)
                {
                    foreach(Player.PlayerInfo Player in QuarterBacks)
                    {
                        
                        Player.QBRWTE p = new Player.QBRWTE();
                        if (sr.EndOfStream) break;
                        string line = sr.ReadLine();
                        string[] pLine = line.Split('|');
                        p.PassYard = pLine[0];
                        p.RushYard = pLine[1];
                        p.ReceivingYards = pLine[2];
                        p.Receptions = pLine[3];
                        p.Touchdowns = pLine[4];
                        p.Interceptions = pLine[5];
                        p.Fumbles = pLine[6];
                        Player.Stats.Add(p);                         
                    }
                }
                Console.WriteLine("The Number of QB is " + QuarterBacks.Count);
                Console.WriteLine("The Number of QB Stats is " + QuarterBacks[0].Stats.Count);
            }
        }
        
        public void RunningBackList(string file)
        {
            using(StreamReader sr = new StreamReader(file))
            {
                sr.ReadLine();
                for(int i = 0; i < 16; i++)
                {
                    foreach (Player.PlayerInfo Player in RunningBacks)
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
                        Player.Stats.Add(p);                        
                    }
                }
                Console.WriteLine("The Number of RB is " + RunningBacks.Count);
                Console.WriteLine("The Number of RB Stats is " + RunningBacks[0].Stats.Count);
            }
        }

         public void TightEndsList(string file)
        {
        
            using(StreamReader sr = new StreamReader(file))
            {
                sr.ReadLine();
                for(int i = 0; i < 16; i++)
                {
                    foreach (Player.PlayerInfo Player in TightEnds)
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
                        Player.Stats.Add(p);
                    }
                }
                Console.WriteLine("The Number of TE is " + TightEnds.Count);
                Console.WriteLine("The Number of TE Stats is " + TightEnds[0].Stats.Count);
            }
        }

        public void WideReceiversList(string file)
        {
            using(StreamReader sr = new StreamReader(file))
            {
                sr.ReadLine();
                for(int i = 0; i < 16; i++)
                {
                    foreach (Player.PlayerInfo Player in WideReceivers)
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
                        Player.Stats.Add(p);                    
                    }
                }
                Console.WriteLine("The Number of WR is " + WideReceivers.Count);
                Console.WriteLine("The Number of WR Stats is " + WideReceivers[0].Stats.Count);
            }
        }

        public void KickerList(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                sr.ReadLine();
                for (int i = 0; i < 16; i++)
                {
                    foreach (Player.PlayerInfo Player in Kickers)
                    {

                        Player.Kicker p = new Player.Kicker();
                        if (sr.EndOfStream) break;
                        string line = sr.ReadLine();
                        string[] pLine = line.Split('|');
                        p.XPMade = pLine[0];
                        p.XPMissed = pLine[1];
                        p.FGGD = pLine[2];
                        p.FGNG = pLine[3];
                        Player.KickerStats.Add(p);
                    }
                }
                Console.WriteLine("The Number of K is " + Kickers.Count);
                Console.WriteLine("The Number of K Stats is " + Kickers[0].KickerStats.Count);
            }
        }

        public void DefenseList(string file)
        {
            for (int i = 0; i < 32; i++)
            {
                Defense.Add(new Player.PlayerInfo());
                Defense[i].Name = Teams[i];
            }
            using (StreamReader sr = new StreamReader(file))
            {
                
                sr.ReadLine();
                for (int i = 0; i < 16; i++)
                {
                    foreach (Player.PlayerInfo Player in Defense)
                    {
                        
                        Player.Defense p = new Player.Defense();
                        string line = sr.ReadLine();
                        string[] pLine = line.Split('|');
                        p.PassYardsAllowed = pLine[0];
                        p.RushYardsAllowed = pLine[1];
                        p.Touchdowns = pLine[2];
                        p.Safeties = pLine[3];
                        p.Interceptions = pLine[4];
                        p.Fumbles = pLine[5];
                        Player.DefStats.Add(p);
                    }
                }
            }
        }

        public void insertPlayerData()
        {
            foreach (Player.PlayerInfo QB in QuarterBacks)
            {
                for(int i = 0; i < QB.Stats.Count; i++)
                {
                    Player.QBRWTE p = QB.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + QB.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") "; 

                }
            }
            foreach(Player.PlayerInfo RB in RunningBacks)
            {
                for (int i = 0; i < RB.Stats.Count; i++)
                {
                    Player.QBRWTE p = RB.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + RB.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";

                }
            }
            foreach (Player.PlayerInfo WR in WideReceivers)
            {
                for (int i = 0; i < WR.Stats.Count; i++)
                {
                    Player.QBRWTE p = WR.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + WR.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";

                }
            }
            foreach (Player.PlayerInfo TE in TightEnds)
            {
                for (int i = 0; i < TE.Stats.Count; i++)
                {
                    Player.QBRWTE p = TE.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + TE.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";

                }
            }
            foreach (Player.PlayerInfo DEF in Defense)
            {
                for (int i = 0; i < DEF.DefStats.Count; i++)
                {
                    Player.Defense p = DEF.DefStats[i];
                    string sql = "INSERT Players.DefenseStats(PlayerID, PassYardsAllowed, RushYardsAllowed, TouchdownsAllowed, Safeties, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + DEF.Name + ", " + p.PassYardsAllowed + ", " + p.RushYardsAllowed + ", " + p.Touchdowns + ", " + p.Safeties + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";

                }
            }
        }
    }
}
