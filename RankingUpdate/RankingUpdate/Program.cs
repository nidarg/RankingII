using System;

namespace RankingUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            Team FCSB = new Team("FCSB", 32);
            Team CFR = new Team("CFR", 30);
            Team Dinamo = new Team("Dinamo", 29);


            Ranking ranking = new Ranking(new[] { FCSB, CFR, Dinamo });
          
            Console.WriteLine(" Ranking before game");
            ranking.PrintAllToConsole();
            Game game = new Game(FCSB, CFR, 0, 2);
            ranking.UpdateRanking(game);
            Console.WriteLine(" Ranking after game");
            ranking.PrintAllToConsole();

            Console.Read();
        }
    }
}
