namespace playingcards.Models
{
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
}