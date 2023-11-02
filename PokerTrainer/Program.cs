namespace PokerTrainer;

static class Program
{
    static void Main()
    {
        Player player = new Player(new Hand(new Deck()), TablePosition.UTG);;
        
        RangeChart.InitCharts();
        Console.WriteLine("Welcome to Poker Trainer!");
        Console.WriteLine("Press A to deal a hand, or press Q to quit");

        /* tests all combinations of cards
           and prints a map of correct answers
           (true - raise, false - check/fold)
        
        List<List<Card>> testCases = new List<List<Card>>();
        for (int i = 1; i <= 13; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                if (i == j)
                {
                    testCases.Add(new List<Card>{new(Card.CardSuit.Hearts, (Card.CardRank) i), new(Card.CardSuit.Spades, (Card.CardRank) j)});
                    continue;
                }

                testCases.Add(i < j
                    ? new List<Card>
                        { new(Card.CardSuit.Hearts, (Card.CardRank)i), new(Card.CardSuit.Hearts, (Card.CardRank)j) }
                    : new List<Card>
                        { new(Card.CardSuit.Hearts, (Card.CardRank)j), new(Card.CardSuit.Spades, (Card.CardRank)i) });
            }
        }
            
        bool[,] map = new bool[13, 13];
        for (int p = 0; p < 5; p++)
        {
            int raise = 0;
            foreach (var hand in testCases)
            {
                player = new Player(new Hand(hand), (TablePosition) p);
                if (RangeChart.ShouldRaise(RangeChart.BasicPreflop, player.Hand, player.Position))
                {
                    map[(int)player.Hand.Cards[0].Rank - 1, (int)player.Hand.Cards[1].Rank - 1] = true;
                    raise++;
                }
            }

            for (int i = 12; i >= 0; i--)
            {
                for (int j = 12; j >= 0; j--) Console.Write(map[i, j] ? "##" : "  ");
                Console.WriteLine();
            }
            Console.WriteLine(raise + " / 169 hands should be raised from " + (TablePosition) p);
        }
        */

        while (true)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    player = new Player(new Hand(new Deck()), (TablePosition) new Random().Next(5));
                    player.PrintPlayerProfile();
                    Console.WriteLine("Press: R -> raise, F -> fold");
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    Console.WriteLine(RangeChart.ShouldRaise(RangeChart.BasicPreflop, player.Hand, player.Position)
                        ? "Correct"
                        : "Wrong, in this situation you should Check or Fold");
                    break;
                    
                case ConsoleKey.F:
                    Console.Clear();
                    Console.WriteLine(RangeChart.ShouldRaise(RangeChart.BasicPreflop, player.Hand, player.Position)
                        ? "Wrong, in this situation you should Raise"
                        : "Correct");
                    break;
            }
        }
    }
}
