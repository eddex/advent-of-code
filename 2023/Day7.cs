namespace _2023;

public static class Day7
{
    public static string Solve1(string inputPath) => Solve(inputPath, false);

    public static string Solve2(string inputPath) => Solve(inputPath, true);

    private static string Solve(string inputPath, bool jIsJoker)
    {
        var input = File.ReadLines(inputPath)
            .Select(l => l.Split(" "))
            .Select(x => (x[0], int.Parse(x[1])));
        var hands = new List<Hand>();
        foreach (var (hand, bid) in input)
        {
            var cards = GetCards(jIsJoker ? hand.Replace("J", "X") : hand);
            var handType = GetHandType(cards);
            hands.Add(new Hand { HandType = handType, Cards = cards, Bid = bid });
        }

        var rankedHands = hands.OrderBy(x => x).ToArray();
        var result = 0L;
        for (var i = 0; i < rankedHands.Length; i++)
            result += (i+1) * rankedHands[i].Bid;

        return result.ToString();
    }

    private static Card[] GetCards(string hand) =>
        hand.Select(x => int.TryParse(x.ToString(), out var number)
            ? (Card)number
            : Enum.Parse<Card>(x.ToString()))
            .ToArray();

    private static HandType GetHandType(Card[] cards)
    {
        var groupedCards = cards
            .GroupBy(c => c)
            .Select(g => (g.Key, g.Count()))
            .OrderByDescending(t => t.Item2)
            .ToArray();

        var jokerCount = groupedCards.SingleOrDefault(g => g.Key == Card.X).Item2;
        if (jokerCount > 0 && groupedCards.Length > 1)
        {
            groupedCards = groupedCards
                .Where(g => g.Key != Card.X)
                .ToArray();
            groupedCards[0].Item2 += jokerCount;
        }

        if (groupedCards.Length == 1)
            return HandType.FiveOfAKind;
        if (groupedCards[0].Item2 == 4)
            return HandType.FourOfAKind;
        if (groupedCards[0].Item2 == 3 && groupedCards[1].Item2 == 2)
            return HandType.FullHouse;
        if (groupedCards[0].Item2 == 3)
            return HandType.ThreeOfAKind;
        if (groupedCards[0].Item2 == 2 && groupedCards[1].Item2 == 2)
            return HandType.TwoPair;
        if (groupedCards[0].Item2 == 2)
            return HandType.OnePair;
        return HandType.HighCard;
    }

    private class Hand : IComparable<Hand>
    {
        public HandType HandType { get; set; }
        public Card[] Cards { get; set; }
        public int Bid { get; set; }

        public int CompareTo(Hand? other)
        {
            if (HandType != other.HandType)
                return HandType > other.HandType ? 1 : -1;

            for (var i = 0; i < Cards.Length; i++)
            {
                if ((int)Cards[i] == (int)other.Cards[i])
                    continue;
                return (int)Cards[i] > (int)other.Cards[i] ? 1 : -1;
            }
            return 0;
        }
    }

    private enum HandType
    {
        HighCard = 0,
        OnePair = 1,
        TwoPair = 2,
        ThreeOfAKind = 3,
        FullHouse = 4,
        FourOfAKind = 5,
        FiveOfAKind = 6
    }

    private enum Card
    {
        X = 1, // joker
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        T = 10,
        J = 11,
        Q = 12,
        K = 13,
        A = 14,
    }
}