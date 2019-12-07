using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FantasyData.Models;

namespace FantasyData.Controller
{
    class RemoveDecimalStats
    {
        public static void removeDecimals(string readerfilepath, string writerfilepath)
        {
            StreamReader reader = new StreamReader(readerfilepath);
            StreamWriter writer = new StreamWriter(writerfilepath);
            string header = reader.ReadLine();
            writer.WriteLine(header);

            while (!reader.EndOfStream)
            {
                string raw_player_info = reader.ReadLine();
                string[] raw_player_info_split = raw_player_info.Split('|');
                string decimals_removed = raw_player_info_split[0] + "|" + raw_player_info_split[1] + "|" + raw_player_info_split[2] + "|" + Math.Round(Convert.ToDecimal(raw_player_info_split[3])).ToString() + "|" + Math.Round(Convert.ToDecimal(raw_player_info_split[4])).ToString() + "|" + raw_player_info_split[5] + "|" + raw_player_info_split[6] + "|" + raw_player_info_split[7];
                writer.WriteLine(decimals_removed);
                // Console.WriteLine(decimals_removed);
            }
            writer.Close();
        }

        public static void makeDataRealisticPls(string readerfilepath, string writerfilepath)
        {
            Random r = new Random();
            StreamReader reader = new StreamReader(readerfilepath);
            StreamWriter writer = new StreamWriter(writerfilepath);
            string header = reader.ReadLine();
            writer.WriteLine(header);

            while (!reader.EndOfStream)
            {
                string raw_player_info = reader.ReadLine();
                string[] raw_player_info_split = raw_player_info.Split('|');
                switch(raw_player_info_split[5])
                {
                    case "QB":
                        if(Convert.ToInt16(raw_player_info_split[2]) > 245) { raw_player_info_split[2] = r.Next(200, 240).ToString(); }
                        break;
                    case "RB":
                        if (Convert.ToInt16(raw_player_info_split[2]) > 240) { raw_player_info_split[2] = r.Next(170, 230).ToString(); }
                        break;
                    case "WR":
                        if (Convert.ToInt16(raw_player_info_split[2]) > 230) { raw_player_info_split[2] = r.Next(160, 220).ToString(); }
                        break;
                    case "TE":
                        if (Convert.ToInt16(raw_player_info_split[2]) > 270) { raw_player_info_split[2] = r.Next(240, 260).ToString(); }
                        break;
                    case "K":
                        if (Convert.ToInt16(raw_player_info_split[2]) > 210) { raw_player_info_split[2] = r.Next(165, 210).ToString(); }
                        break;
                }
                DateTime birthdate = Convert.ToDateTime(raw_player_info_split[4]);
                int age = int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(birthdate.ToString("yyyyMMdd")) / 10000;
                int years_pro = Convert.ToInt16(raw_player_info_split[3]);
                int number_of_eligible_years = (age - 21) / 10000;
                if(years_pro > number_of_eligible_years)
                {
                    years_pro = number_of_eligible_years;
                }
                raw_player_info_split[4] = years_pro.ToString();
                string realisticized = raw_player_info_split[0] + "|" + raw_player_info_split[1] + "|" + raw_player_info_split[2] + "|" + raw_player_info_split[3] + "|" + raw_player_info_split[4] + "|" + raw_player_info_split[5];
                writer.WriteLine(realisticized);
                // Console.WriteLine(realisticized);
            }
            writer.Close();
        }

        static void Main(string[] args)
        {
            string source_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataQBStatsDecimal.txt";
            string destination_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataQBStats.txt";
            removeDecimals(source_filepath, destination_filepath);

            source_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataRBStatsDecimal.txt";
            destination_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataRBStats.txt";
            removeDecimals(source_filepath, destination_filepath);

            source_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataTEStatsDecimal.txt";
            destination_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataTEStats.txt";
            removeDecimals(source_filepath, destination_filepath);

            source_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataWRStatsDecimal.txt";
            destination_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataWRStats.txt";
            removeDecimals(source_filepath, destination_filepath);

            source_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\GeneratedDataPlayerInfo.txt";
            destination_filepath = "..\\..\\..\\..\\..\\..\\..\\Desktop\\TEAM5_560\\MoreRealisticDataPlayerInfo.txt";
            makeDataRealisticPls(source_filepath, destination_filepath);
            Console.ReadLine();
        }
    }
}
