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

        private void Swap(Team team1,Team team2)
        {
            Team t = team1;
            team1 = team2;
            team2 = t;
        }

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

                if(i>0 && teams[i].CompareTeamsPointsGreaterThan(teams[i - 1]))
                {
                    Swap(teams[i], teams[i - 1]);
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
    }
}
