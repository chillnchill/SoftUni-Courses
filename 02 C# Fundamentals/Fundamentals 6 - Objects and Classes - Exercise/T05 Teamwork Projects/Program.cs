using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Teamwork_Projects
{
     class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>(); 

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                var creator = input[0];
                var teamName = input[1];

                if (teams.Any(team => team.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!"); 
                }
                else
                {
                    var team = new Team();
                    team.TeamName = teamName;
                    team.Creator = creator;
                    team.MemberNames = new List<string>();
                    teams.Add(team);

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string[] commands = Console.ReadLine().Split("->");

            while (commands[0] != "end of assignment")
            {
                string member = commands[0];
                string teamName = commands[1];

                
                if (teams.Any(teams => teams.MemberNames.Contains(member)) || teams.Any(teams => teams.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else if (teams.All(teams => teams.TeamName != teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else
                {
                   var currentTeam = teams.Find(teams => teams.TeamName == teamName);
                   currentTeam.MemberNames.Add(member);
                }

                commands = Console.ReadLine().Split("->");
            }
            //checking if team has at least 1 member
            var fullTeams = teams.Where(x => x.MemberNames.Count > 0);
            //checking if team has no members
            var emptyTeams = teams.Where(x => x.MemberNames.Count == 0);

            foreach (var team in fullTeams.OrderByDescending(x => x.MemberNames.Count).ThenBy(y => y.TeamName))
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.MemberNames.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in emptyTeams.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
    class Team
    {
        public string Creator { get; set; }

        public string TeamName { get; set; }

        public List<string> MemberNames { get; set; }
    }
}
