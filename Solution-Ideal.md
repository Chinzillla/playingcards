
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

    internal static class RankExtensions
    {
        public static string ToDisplayString(this Rank rank) => rank switch
        {
            Rank.Ace => "A",
            Rank.Jack => "J",
            Rank.Queen => "Q",
            Rank.King => "K",
            _ => ((int)rank).ToString()
        };
    }

    internal class PlayingCard : Card
    {
        private Suit Suit { get; }
        private Rank Rank { get; }

        public PlayingCard(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override int CardValue => (int)Rank;

        public override string ToString()
        {
            return $"{Rank.ToDisplayString()} of {Suit}";
        }

        public static PlayingCard Parse(string suitText, string valueText)
        {
            Suit suit = Enum.Parse<Suit>(suitText, ignoreCase: true);

            Rank rank = valueText.ToUpper() switch
            {
                "A" => Rank.Ace,
                "2" => Rank.Two,
                "3" => Rank.Three,
                "4" => Rank.Four,
                "5" => Rank.Five,
                "6" => Rank.Six,
                "7" => Rank.Seven,
                "8" => Rank.Eight,
                "9" => Rank.Nine,
                "10" => Rank.Ten,
                "J" => Rank.Jack,
                "Q" => Rank.Queen,
                "K" => Rank.King,
                _ => throw new ArgumentException($"Unknown card value: {valueText}")
            };

            return new PlayingCard(suit, rank);
        }
    }

    public class Game
    {
        private readonly List<Card> cards;

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