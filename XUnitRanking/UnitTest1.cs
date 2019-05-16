using System;
using Xunit;
using RankingUpdate;

namespace XUnitRanking
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("FCSB",32,"FCSB 32")]
        public void TestPrintTeam(string name,int points,string expected)
        {
            Team team = new Team(name, points);
            string actual = team.PrintTeam();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FCSB", 32, "CFR", 30,false)]
        public void TestCompareTeamsNames(string firstTeamName, int firstTeamPoints,string secondTeamName,int secondTeamPoints, bool expected)
        {
            Team firstTeam = new Team(firstTeamName,firstTeamPoints);
            Team secondTeam = new Team(secondTeamName, secondTeamPoints);
            bool actual = firstTeam.CompareTeamsNames(secondTeam);
            Assert.Equal(expected, actual);
        }
    }
}
