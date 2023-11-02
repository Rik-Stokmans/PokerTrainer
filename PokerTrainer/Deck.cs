using System.Security.Cryptography;

namespace PokerTrainer;

public class Deck
{
    private Random _rng = new Random();
    
    public List<Card> Cards = new();
    
    public Deck()
    {
        InitDeck();
        Shuffle();
    }

    private void InitDeck()
    {
        foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
        {
            foreach (Card.CardRank rank in Enum.GetValues(typeof(Card.CardRank)))
            {
                Cards.Add(new Card(suit, rank));
            }
        }
    }
    
    private void Shuffle()
    {
        var n = Cards.Count;
        while (n > 1)
        { 
            n--; 
            int k = _rng.Next(n + 1);  
            (Cards[k], Cards[n]) = (Cards[n], Cards[k]);
        }
    }
    
    public Card Draw()
    {
        if (Cards.Count == 0) throw new Exception("No cards left in deck");
        var card = Cards[0];
        Cards.RemoveAt(0);
        return card;
    }
    
    
}