using System;
using System.Collections.Generic;
using System.Text;

namespace RankingUpdate
{
    public class Game
    {
        private readonly Team firstTeam;
        private readonly Team secondTeam;
        private readonly int firstTeamScore;
        private readonly int secondTeamScore;

        public Game(Team firstTeam, Team secondTeam, int firstTeamScore, int secondTeamScore)
        {
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
            this.firstTeamScore = firstTeamScore;
            this.secondTeamScore = secondTeamScore;
        }

        public int GetTeamPointsAfterGame(Team team)
        {
            if (firstTeamScore > secondTeamScore) return team.AddPoints(3);
            else if (firstTeamScore == secondTeamScore) return team.AddPoints(1);
            else return team.GetPointsFromPrint();
        }

    }
}
