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

        [Theory]
        [InlineData("FCSB", 30, "CFR", 32, false)]
        public void TestCompareTeamsPoints(string firstTeamName, int firstTeamPoints, string secondTeamName, int secondTeamPoints, bool expected)
        {
            Team firstTeam = new Team(firstTeamName, firstTeamPoints);
            Team secondTeam = new Team(secondTeamName, secondTeamPoints);
            bool actual = firstTeam.CompareTeamsNames(secondTeam);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FCSB", 30, "FCSB")]
        public void TestGetNameFromPrint(string teamName, int teamPoints, string expected)
        {
            Team team = new Team(teamName, teamPoints);
            string actual = team.GetNameFromPrint();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FCSB", 30, 30)]
        public void TestGetPointsFromPrint(string teamName, int teamPoints, int expected)
        {
            Team team = new Team(teamName, teamPoints);
            int actual = team.GetPointsFromPrint();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FCSB", 30,"CFR",31,3,1, 33)]
        public void TestGetFirstTeamPointsAfterGame(string firstTeamName, int firstTeamPoints,string secondTeamName,int secondTeamPoints,int firstScore,int secondScore, int expected)
        {
            Team firstTeam = new Team(firstTeamName, firstTeamPoints);
            Team secondTeam = new Team(secondTeamName, secondTeamPoints);
            Game game = new Game(firstTeam, secondTeam, firstScore, secondScore);
            int actual = game.GetTeamPointsAfterGame(firstTeam);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FCSB", 30, "CFR", 31, 3, 1, "FCSB 33")]
        public void TestGetFirstUpdatedTeam(string firstTeamName, int firstTeamPoints, string secondTeamName, int secondTeamPoints, int firstScore, int secondScore, string expected)
        {
            Team firstTeam = new Team(firstTeamName, firstTeamPoints);
            Team secondTeam = new Team(secondTeamName, secondTeamPoints);
            Game game = new Game(firstTeam, secondTeam, firstScore, secondScore);
            //int actual = game.GetTeamPointsAfterGame(firstTeam);
            Team firstTeamUpdated = game.GetFirstUpdatedTeam();
            string actual = firstTeamUpdated.PrintTeam();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FCSB", 30, "CFR", 31, 1, 1, "CFR 32")]
        public void TestGetSecondUpdatedTeam(string firstTeamName, int firstTeamPoints, string secondTeamName, int secondTeamPoints, int firstScore, int secondScore, string expected)
        {
            Team firstTeam = new Team(firstTeamName, firstTeamPoints);
            Team secondTeam = new Team(secondTeamName, secondTeamPoints);
            Game game = new Game(firstTeam, secondTeam, firstScore, secondScore);
            //int actual = game.GetTeamPointsAfterGame(firstTeam);
            Team secondTeamUpdated = game.GetSecondUpdatedTeam();
            string actual = secondTeamUpdated.PrintTeam();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FCSB", 32, "CFR", 30, "Dinamo", 29, new [] {"FCSB 32", "CFR 30", "Dinamo 29" })]
        public void TestPrintAll(string firstName, int firstPoints, string secondName, int secondPoints, string thirdName, int thirdPoints,  string[] expected)
        {
            Team firstTeam = new Team(firstName, firstPoints);
            Team secondTeam = new Team(secondName, secondPoints);
            Team thirdTeam = new Team(thirdName, thirdPoints);
            Team[] rankingTeams = new Team[] { firstTeam, secondTeam, thirdTeam };
            Ranking r = new Ranking(rankingTeams);
            string[] actual = r.PrintAll();
            Assert.Equal(expected, actual);
        }
    }
}
