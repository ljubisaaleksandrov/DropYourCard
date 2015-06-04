using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropYourCard.Data.Models;

namespace DropYourCard.Helpers
{
    public static class CsvHelper
    {
        public static List<int> GetPlayingList(Room room)
        {
            return GetList(room.PlayingList);
        }

        public static List<int> GetWaitingList(Room room)
        {
            return GetList(room.WaitingList);
        }

        public static string SetPlayersIds(List<int> playerIds)
        {
            return TrimCsv(playerIds.Aggregate("", (current, id) => current + ("," + id.ToString())));
        }
        
        public static string TrimCsv(string str)
        {
            return str.Trim(' ',',');
        }

        public static string[] TrimNSplitCsv(string str)
        {
            return TrimCsv(str).Split(',');
        }

        private static List<int> GetList(string playersArray)
        {
            string[] players = TrimNSplitCsv(playersArray);
            List<int> playersList = new List<int>(0);
            if (players.Any())
                return playersList;

            playersList.AddRange(players.Select(Int32.Parse));

            return playersList;
        }
    }
}