using YamlDotNet.RepresentationModel;
// ReSharper disable InconsistentNaming

namespace PokerTrainer;

public static class RangeChart
{
    // ReSharper disable once IdentifierTypo
    private static RangeIndex UTG = new(TablePosition.UTG); 
    private static RangeIndex MP_ = new(TablePosition.MP); 
    private static RangeIndex CO_ = new(TablePosition.CO); 
    private static RangeIndex BTN = new(TablePosition.BTN); 
    private static RangeIndex SB_ = new(TablePosition.SB);
    private static RangeIndex FLD = new(TablePosition.FOLD); 
    
    public static RangeIndex[,] BasicPreflop = new RangeIndex[13, 13];

    public static void InitCharts()
    {
        BasicPreflop = new RangeIndex[,]
        {
            { UTG, UTG, UTG, UTG, UTG, UTG, UTG, UTG, UTG, UTG, UTG, UTG, UTG },
            { UTG, UTG, UTG, UTG, UTG, MP_, MP_, MP_, CO_, CO_, CO_, BTN, BTN },
            { UTG, UTG, UTG, UTG, UTG, MP_, CO_, BTN, SB_, SB_, SB_, SB_, SB_ },
            { UTG, UTG, UTG, UTG, UTG, MP_, CO_, BTN, SB_, SB_, SB_, SB_, SB_ },
            { MP_, MP_, MP_, MP_, UTG, MP_, CO_, BTN, SB_, SB_, SB_, SB_, SB_ },
            { CO_, CO_, CO_, CO_, CO_, UTG, MP_, CO_, BTN, SB_, FLD, FLD, FLD },
            { BTN, BTN, BTN, BTN, BTN, BTN, UTG, MP_, CO_, BTN, SB_, FLD, FLD },
            { BTN, SB_, SB_, SB_, SB_, SB_, SB_, UTG, MP_, CO_, BTN, SB_, FLD },
            { BTN, FLD, FLD, FLD, FLD, FLD, SB_, SB_, UTG, FLD, FLD, FLD, FLD },
            { BTN, FLD, FLD, FLD, FLD, FLD, FLD, SB_, SB_, UTG, FLD, FLD, FLD },
            { BTN, FLD, FLD, FLD, FLD, FLD, FLD, FLD, SB_, SB_, UTG, FLD, FLD },
            { BTN, FLD, FLD, FLD, FLD, FLD, FLD, FLD, FLD, FLD, FLD, UTG, FLD },
            { BTN, FLD, FLD, FLD, FLD, FLD, FLD, FLD, FLD, FLD, FLD, FLD, UTG }
        };
    }

    public static bool ShouldRaise(RangeIndex[,] RangeChart, Hand hand, TablePosition position)
    {
        int x = 14 - (int) hand.Cards[0].Rank;
        int y = 14 - (int) hand.Cards[1].Rank;
        
        RangeIndex rangeIndex = RangeChart[x, y];

        return (int) position >= (int) rangeIndex.PositionToRaiseFrom;
    }
}