# Solution for algomonster (Older C# Compiler)

```c#
using System;
using System.Collections.Generic;

class Solution
{
    internal abstract class Card
    {
        public abstract int CardValue { get; }
    }
    
    internal enum Suit
    {
        Hearts,
        Spades,
        Clubs,
        Diamonds
    }
    
    internal enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
    internal class PlayingCard : Card
    {
        private Suit suit;
        private Rank rank;
        
        public PlayingCard(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
        
        public override int CardValue
        {
            get { return (int)rank; }
        }
        
        public override string ToString()
        {
            return RankToString(rank) + " of " + suit.ToString();
        }

        private static string RankToString(Rank rank)
        {
            switch (rank)
            {
                case Rank.Ace: return "A";
                case Rank.Jack: return "J";
                case Rank.Queen: return "Q";
                case Rank.King: return "K";
                default: return ((int)rank).ToString();
            }
        }

        public static Rank ParseRank(string value)
        {
            switch (value.ToUpper())
            {
                case "A": return Rank.Ace;
                case "2": return Rank.Two;
                case "3": return Rank.Three;
                case "4": return Rank.Four;
                case "5": return Rank.Five;
                case "6": return Rank.Six;
                case "7": return Rank.Seven;
                case "8": return Rank.Eight;
                case "9": return Rank.Nine;
                case "10": return Rank.Ten;
                case "J": return Rank.Jack;
                case "Q": return Rank.Queen;
                case "K": return Rank.King;
                default: throw new ArgumentException("Unknown card value: " + value);
            }
        }

        public static PlayingCard Parse(string suitText, string valueText)
        {
            Suit suit = (Suit)Enum.Parse(typeof(Suit), suitText, true);
            Rank rank = ParseRank(valueText);
            return new PlayingCard(suit, rank);
        }
    }

    public class Game
    {
        private List<Card> cards;

        public Game()
        {
            cards = new List<Card>();
        }

        public void AddCard(string suit, string value)
        {
            cards.Add(PlayingCard.Parse(suit, value));
        }

        public string CardString(int card)
        {
            return cards[card].ToString();
        }

        public bool CardBeats(int cardA, int cardB)
        {
            return cards[cardA].CardValue > cards[cardB].CardValue;
        }
    }

    public static void Main()
    {
        Game game = new Game();
        string[] segs = Console.ReadLine().Split(' ');
        game.AddCard(segs[0], segs[1]);
        Console.WriteLine(game.CardString(0));
        segs = Console.ReadLine().Split(' ');
        game.AddCard(segs[0], segs[1]);
        Console.WriteLine(game.CardString(1));
        Console.WriteLine(game.CardBeats(0, 1) ? "true" : "false");
    }
}
```