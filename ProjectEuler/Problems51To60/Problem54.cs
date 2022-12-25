using System.Collections;
using System.Text;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Poker hands.
/// <see href="https://projecteuler.net/problem=54" />
/// </summary>
public static class Problem54
{
    /// <summary>
    /// Suits are ranked alphabetically as in bridge.
    /// </summary>
    private enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    private enum Rank
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    private struct Card
    {
        public readonly byte Value;
        public readonly Suit Suit;

        public Card(string card)
        {
            // Get the card value.
            Value = card[0] switch
            {
                'A' => 14,
                'K' => 13,
                'Q' => 12,
                'J' => 11,
                'T' => 10,
                _ => (byte)(card[0] - '0')
            };

            // Get the card suit.
            Suit = card[1] switch
            {
                'C' => Suit.Clubs,
                'D' => Suit.Diamonds,
                'H' => Suit.Hearts,
                _ => Suit.Spades
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            // Generate the value part.
            string value = Value switch
            {
                14 => "A",
                13 => "K",
                12 => "Q",
                11 => "J",
                10 => "\u2491",
                _ => Value.ToString()
            };
            sb.Append(value);

            // Generate the suit part.
            string suit = Suit switch
            {
                Suit.Clubs => "\u2663",
                Suit.Diamonds => "\u2666",
                Suit.Hearts => "\u2665",
                _ => "\u2660"
            };
            sb.Append(suit);

            return sb.ToString();
        }
    }

    private class CardComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is not Card card1 || y is not Card card2)
            {
                throw new ArgumentException(
                    "This IComparer is for comparing strings representing playing cards.");
            }

            // Compare card values.
            if (card1.Value < card2.Value)
            {
                return -1;
            }
            if (card1.Value > card2.Value)
            {
                return 1;
            }

            // Compare card suits alphabetically (C, D, H, S).
            if (card1.Suit < card2.Suit)
            {
                return -1;
            }
            if (card1.Suit > card2.Suit)
            {
                return 1;
            }

            // They are the same card.
            return 0;
        }
    }

    private class HandComparer : IComparer
    {
        private static int CompareHands(Card[] hand1, Card[] hand2)
        {
            if (hand1.Length != hand2.Length)
            {
                throw new ArgumentException("Both hands must have the same number of cards.");
            }

            // Compare each card from highest value to lowest.
            for (int i = hand1.Length - 1; i >= 0; i--)
            {
                if (hand1[i].Value < hand2[i].Value)
                {
                    return -1;
                }
                if (hand1[i].Value > hand2[i].Value)
                {
                    return 1;
                }
            }

            return 0;
        }

        public int Compare(object? x, object? y)
        {
            if (x is not Card[] hand1 || y is not Card[] hand2)
            {
                throw new ArgumentException(
                    "This IComparer is for comparing arrays of cards representing players' hands.");
            }

            // Compare ranks.
            Rank rank1 = GetHandRank(hand1, out dynamic? info1);
            Rank rank2 = GetHandRank(hand2, out dynamic? info2);
            if (rank1 < rank2)
            {
                return -1;
            }
            if (rank1 > rank2)
            {
                return 1;
            }

            // Same rank, need to compare card values.
            switch (rank1)
            {
                case Rank.HighCard:
                    // Compare highest card.
                    return CompareHands(hand1, hand2);

                case Rank.OnePair:
                    // Compare the values of the pairs.
                    if (info1!.PairValue < info2!.PairValue)
                    {
                        return -1;
                    }
                    if (info1!.PairValue > info2!.PairValue)
                    {
                        return 1;
                    }
                    // Compare other 3 cards.
                    return CompareHands(info1!.OtherCards, info2!.OtherCards);

                case Rank.TwoPairs:
                    // Compare the values of the high pairs.
                    if (info1!.HighPairValue < info2!.HighPairValue)
                    {
                        return -1;
                    }
                    if (info1!.HighPairValue > info2!.HighPairValue)
                    {
                        return 1;
                    }
                    // Compare the values of the low pairs.
                    if (info1!.LowPairValue < info2!.LowPairValue)
                    {
                        return -1;
                    }
                    if (info1!.LowPairValue > info2!.LowPairValue)
                    {
                        return 1;
                    }
                    // Compare other card.
                    if (info1!.OtherCardValue < info2!.OtherCardValue)
                    {
                        return -1;
                    }
                    if (info1!.OtherCardValue > info2!.OtherCardValue)
                    {
                        return 1;
                    }
                    return 0;

                case Rank.ThreeOfAKind:
                    // Compare the values of the pairs.
                    if (info1!.TrioValue < info2!.TrioValue)
                    {
                        return -1;
                    }
                    if (info1!.TrioValue > info2!.TrioValue)
                    {
                        return 1;
                    }
                    // Compare other cards.
                    return CompareHands(info1!.OtherCards, info2!.OtherCards);

                case Rank.Straight:
                    // Compare highest card.
                    return CompareHands(hand1, hand2);

                case Rank.Flush:
                    // Compare highest card.
                    return CompareHands(hand1, hand2);

                case Rank.FullHouse:
                    // Compare the values of the trios.
                    if (info1!.TrioValue < info2!.TrioValue)
                    {
                        return -1;
                    }
                    if (info1!.TrioValue > info2!.TrioValue)
                    {
                        return 1;
                    }
                    // Compare the values of the pairs.
                    if (info1!.PairValue < info2!.PairValue)
                    {
                        return -1;
                    }
                    if (info1!.PairValue > info2!.PairValue)
                    {
                        return 1;
                    }
                    return 0;

                case Rank.FourOfAKind:
                    // Compare the values of the quartets.
                    if (info1!.QuartetValue < info2!.QuartetValue)
                    {
                        return -1;
                    }
                    if (info1!.QuartetValue > info2!.QuartetValue)
                    {
                        return 1;
                    }
                    // Compare other card.
                    if (info1!.OtherCardValue < info2!.OtherCardValue)
                    {
                        return -1;
                    }
                    if (info1!.OtherCardValue > info2!.OtherCardValue)
                    {
                        return 1;
                    }
                    return 0;

                case Rank.StraightFlush:
                    // Compare highest card.
                    return CompareHands(hand1, hand2);

                case Rank.RoyalFlush:
                    // Two royal flushes are equal.
                    return 0;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static Card[] SortCards(Card[] hand)
    {
        // Copy the array of cards.
        Card[] cards = new Card[5];
        hand.CopyTo(cards, 0);

        // Sort the array using our custom comparer.
        Array.Sort(cards, new CardComparer());

        return cards;
    }

    private static bool IsRoyalFlush(Card[] hand, out dynamic? info)
    {
        for (int i = 0; i < 5; i++)
        {
            if (hand[i].Suit != hand[0].Suit || hand[i].Value != i + 10)
            {
                info = null;
                return false;
            }
        }

        info = new
        {
            hand[0].Suit
        };
        return true;
    }

    private static bool IsStraightFlush(Card[] hand, out dynamic? info)
    {
        info = null;

        for (int i = 1; i < 5; i++)
        {
            if (hand[i].Suit != hand[0].Suit || hand[i].Value != hand[0].Value + i)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsFourOfAKind(Card[] hand, out dynamic? info)
    {
        // Try starting from position 0 and position 1.
        for (int i = 0; i <= 1; i++)
        {
            bool matches = true;

            // Test the next 3 cards against the start card.
            for (int j = i + 1; j <= i + 3; j++)
            {
                if (hand[j].Value != hand[i].Value)
                {
                    matches = false;
                    break;
                }
            }

            if (matches)
            {
                // Get the other card in case we need it for comparing hands.
                info = new
                {
                    QuartetValue = hand[i].Value,
                    OtherCardValue = hand[i == 0 ? 4 : 0]
                };
                return true;
            }
        }

        info = null;
        return false;
    }

    private static bool IsFullHouse(Card[] hand, out dynamic? info)
    {
        // Check for 3, 2.
        if ((hand[0].Value == hand[1].Value) && (hand[1].Value == hand[2].Value)
            && (hand[2].Value != hand[3].Value) && (hand[3].Value == hand[4].Value))
        {
            info = new
            {
                TrioValue = hand[0].Value,
                PairValue = hand[3].Value
            };
            return true;
        }

        // Check for 2, 3.
        if ((hand[0].Value == hand[1].Value) && (hand[1].Value != hand[2].Value)
            && (hand[2].Value == hand[3].Value) && (hand[3].Value == hand[4].Value))
        {
            info = new
            {
                TrioValue = hand[2].Value,
                PairValue = hand[0].Value
            };
            return true;
        }

        info = null;
        return false;
    }

    private static bool IsFlush(Card[] hand, out dynamic? info)
    {
        info = null;

        for (int i = 1; i < 5; i++)
        {
            if (hand[i].Suit != hand[0].Suit)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsStraight(Card[] hand, out dynamic? info)
    {
        for (int i = 1; i < 5; i++)
        {
            if (hand[i].Value != hand[0].Value + i)
            {
                info = null;
                return false;
            }
        }

        info = new
        {
            HighValue = hand[4].Value
        };
        return true;
    }

    private static bool IsThreeOfAKind(Card[] hand, out dynamic? info)
    {
        // The sequence could start at position 0, 1, or 2.
        for (int i = 0; i <= 2; i++)
        {
            bool matches = true;

            // Test the next 2 cards against the start card.
            for (int j = i + 1; j <= i + 2; j++)
            {
                if (hand[j].Value != hand[i].Value)
                {
                    matches = false;
                    break;
                }
            }

            if (!matches)
            {
                continue;
            }

            // Get the other cards in case we need them for comparing hands.
            List<Card> otherCards = new();
            for (int k = 0; k < 5; k++)
            {
                if (k < i || k > i + 2)
                {
                    otherCards.Add(hand[k]);
                }
            }
            info = new
            {
                TrioValue = hand[i].Value,
                OtherCards = otherCards.ToArray()
            };
            return true;
        }

        info = null;
        return false;
    }

    private static bool IsTwoPairs(Card[] hand, out dynamic? info)
    {
        // Check for 2, 2, 1.
        if ((hand[0].Value == hand[1].Value) && (hand[1].Value != hand[2].Value)
            && (hand[2].Value == hand[3].Value) && (hand[3].Value != hand[4].Value))
        {
            info = new
            {
                HighPairValue = hand[2].Value,
                LowPairValue = hand[0].Value,
                OtherCardValue = hand[4].Value
            };
            return true;
        }

        // Check for 2, 1, 2.
        if ((hand[0].Value == hand[1].Value) && (hand[1].Value != hand[2].Value)
            && (hand[2].Value != hand[3].Value) && (hand[3].Value == hand[4].Value))
        {
            info = new
            {
                HighPairValue = hand[3].Value,
                LowPairValue = hand[0].Value,
                OtherCardValue = hand[2].Value
            };
            return true;
        }

        // Check for 1, 2, 2.
        if ((hand[0].Value != hand[1].Value) && (hand[1].Value == hand[2].Value)
            && (hand[2].Value != hand[3].Value) && (hand[3].Value == hand[4].Value))
        {
            info = new
            {
                HighPairValue = hand[3].Value,
                LowPairValue = hand[1].Value,
                OtherCardValue = hand[0].Value
            };
            return true;
        }

        info = null;
        return false;
    }

    /// <summary>
    /// Checks for one pair.
    /// Method assumes checks have already been made for 3-of-a-kind and other higher-value hands.
    /// </summary>
    /// <param name="hand">The hand.</param>
    /// <param name="info">A container for additional information.</param>
    /// <returns></returns>
    private static bool IsOnePair(Card[] hand, out dynamic? info)
    {
        // The sequence could start at position 0, 1, 2, or 3.
        for (int i = 0; i <= 3; i++)
        {
            if (hand[i].Value == hand[i + 1].Value)
            {
                // Get the other cards in case we need them for comparing hands.
                List<Card> otherCards = new();
                for (int k = 0; k < 5; k++)
                {
                    if (k < i || k > i + 1)
                    {
                        otherCards.Add(hand[k]);
                    }
                }
                info = new
                {
                    PairValue = hand[i].Value,
                    OtherCards = otherCards.ToArray()
                };
                return true;
            }
        }

        info = null;
        return false;
    }

    private static Card[] ConstructHand(string[] cards)
    {
        Card[] hand = new Card[5];
        for (int i = 0; i < 5; i++)
        {
            hand[i] = new Card(cards[i]);
        }
        return hand;
    }

    private static void PrintCard(Card card)
    {
        ConsoleColor originalBackgroundColor = Console.BackgroundColor;
        ConsoleColor originalForegroundColor = Console.ForegroundColor;

        // Set the card colours.
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = card.Suit is Suit.Hearts or Suit.Diamonds ? ConsoleColor.DarkRed
            : ConsoleColor.Black;

        // Write the card.
        Console.Write($" {card} ");

        // Restore original colours.
        Console.BackgroundColor = originalBackgroundColor;
        Console.ForegroundColor = originalForegroundColor;
    }

    private static void PrintHand(IEnumerable<Card> hand)
    {
        foreach (Card card in hand)
        {
            Console.Write(' ');
            PrintCard(card);
        }
    }

    private static void PrintPlayerHand(int playerNumber, Card[] hand)
    {
        dynamic? info;
        Console.Write($"Player {playerNumber} has ");
        string rank;
        if (IsRoyalFlush(hand, out info))
        {
            rank = "a royal flush";
        }
        else if (IsStraightFlush(hand, out info))
        {
            rank = "a straight flush";
        }
        else if (IsFourOfAKind(hand, out info))
        {
            rank = "four of a kind";
        }
        else if (IsFullHouse(hand, out info))
        {
            rank = "a full house";
        }
        else if (IsFlush(hand, out info))
        {
            rank = "a flush";
        }
        else if (IsStraight(hand, out info))
        {
            rank = "a straight";
        }
        else if (IsThreeOfAKind(hand, out info))
        {
            rank = "three of a kind";
        }
        else if (IsTwoPairs(hand, out info))
        {
            rank = "two pairs";
        }
        else if (IsOnePair(hand, out info))
        {
            rank = "one pair";
        }
        else
        {
            rank = "nothing";
        }

        Console.Write($"{rank}:".PadRight(18));
        PrintHand(hand);
        Console.WriteLine();
    }

    private static Rank GetHandRank(Card[] hand, out dynamic? info)
    {
        if (IsRoyalFlush(hand, out info))
        {
            return Rank.RoyalFlush;
        }
        if (IsStraightFlush(hand, out info))
        {
            return Rank.StraightFlush;
        }
        if (IsFourOfAKind(hand, out info))
        {
            return Rank.FourOfAKind;
        }
        if (IsFullHouse(hand, out info))
        {
            return Rank.FullHouse;
        }
        if (IsFlush(hand, out info))
        {
            return Rank.Flush;
        }
        if (IsStraight(hand, out info))
        {
            return Rank.Straight;
        }
        if (IsThreeOfAKind(hand, out info))
        {
            return Rank.ThreeOfAKind;
        }
        if (IsTwoPairs(hand, out info))
        {
            return Rank.TwoPairs;
        }
        if (IsOnePair(hand, out info))
        {
            return Rank.OnePair;
        }
        return Rank.HighCard;
    }

    public static long Answer()
    {
        // Load the hands.
        string dataFilePath = Utility.GetDataFilePath("p054_poker.txt");
        string[] games = File.ReadAllLines(dataFilePath);

        // Create the hand comparer.
        HandComparer comparer = new();

        // Count up how many games Player 1 wins.
        int count = 0;

        // Check each game.
        foreach (string game in games)
        {
            Console.WriteLine();
            string[] cards = game.Split(' ');
            Card[] player1Hand = SortCards(ConstructHand(cards[..5]));
            Card[] player2Hand = SortCards(ConstructHand(cards[5..]));
            PrintPlayerHand(1, player1Hand);
            PrintPlayerHand(2, player2Hand);
            int result = comparer.Compare(player1Hand, player2Hand);
            switch (result)
            {
                case 1:
                    Console.WriteLine("Player 1 wins! :D");
                    count++;
                    break;

                case -1:
                    Console.WriteLine("Player 2 wins. ;(");
                    break;
            }
        }

        return count;
    }
}
