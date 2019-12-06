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
                Console.WriteLine(decimals_removed);
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

            Console.ReadLine();
        }
    }
}
