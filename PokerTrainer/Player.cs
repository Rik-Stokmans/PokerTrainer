namespace PokerTrainer;

public class Player
{
    public readonly Hand Hand;
    public readonly TablePosition Position;
    
    
    public Player(Hand hand, TablePosition position)
    {
        Hand = hand;
        Position = position;
    }
    

    public void PrintPlayerProfile()
    {
        Console.WriteLine("Cards: " + Hand.GetStringRepresentation());
        Console.WriteLine("Position: " + Position);
    }
}