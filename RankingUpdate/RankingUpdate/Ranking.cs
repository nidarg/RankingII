using System;
using System.Collections.Generic;
using System.Text;

namespace RankingUpdate
{
    public class Ranking
    {
        Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        //public void Swap(ref Team team1,ref Team team2)
        //{
        //    Team t = team1;
        //    team1 = team2;
        //    team2 = t;
        //}

        public void UpdateRanking(Game game)
        {
            Team firstPlayingTeam = game.GetFirstUpdatedTeam();
            Team secondPlayingTeam = game.GetSecondUpdatedTeam();

            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].CompareTeamsNames(firstPlayingTeam) && teams[i].CompareTeamsPointsLessThan(firstPlayingTeam))
                {
                    teams[i] = firstPlayingTeam;

                }
                    
                 else if(teams[i].CompareTeamsNames(secondPlayingTeam) && teams[i].CompareTeamsPointsLessThan(secondPlayingTeam))
                {
                    teams[i] = secondPlayingTeam;
                    
                }
                if (i > 0 && teams[i].CompareTeamsPointsGreaterThan(teams[i - 1]))
                {
                    Team t = teams[i];
                    teams[i] = teams[i - 1];
                    teams[i - 1] = t;
                }


            }
        }

        public string[] PrintAll()
        {
            string[] allTeams = new string[teams.Length];
            for(int i = 0; i < teams.Length; i++)
            {
                allTeams[i] = teams[i].PrintTeam();
            }
            return allTeams;
        }

        public void PrintAllToConsole()
        {
            foreach (Team team in teams)
            {
                Console.WriteLine(team.PrintTeam());
            }
        }
    }
}
