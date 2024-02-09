using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count { get { return this.Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (String.IsNullOrEmpty(player.Name) || String.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            if (OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            Players.Add(player);
            OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player player = Players.Where(n => n.Name == name).FirstOrDefault();

            if (player != null)
            {
                Players.Remove(player);
                OpenPositions++;
                return true;
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            List<Player> playersToRemove = Players.Where(p => p.Position == position).ToList();
            int removeCount = playersToRemove.Count;

            if (playersToRemove.Count > 0)
            {
                foreach (var player in playersToRemove)
                {
                    Players.Remove(player);
                }
                OpenPositions += removeCount;
                return removeCount;
            }
            
            return 0;                
        }

        public Player RetirePlayer(string name)
        {
            Player player = Players.FirstOrDefault(n => n.Name == name);

            if (player != null)
            {
                player.Retired = true;
            }
            return player;

        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> toBeAwarded = Players.Where(p => p.Games >= games).ToList();
            return toBeAwarded;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            List<Player> activePlayers = Players.Where(p => p.Retired != true).ToList();

            foreach (var player in activePlayers)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}

