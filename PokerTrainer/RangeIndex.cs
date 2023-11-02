namespace PokerTrainer;

public class RangeIndex
{
    
    public readonly TablePosition PositionToRaiseFrom;
    
    public RangeIndex(TablePosition positionToRaiseFrom)
    {
        PositionToRaiseFrom = positionToRaiseFrom;
    }
}