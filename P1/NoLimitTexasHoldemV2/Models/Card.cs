namespace NoLimitTexasHoldemV2.Models
{
    public class Card
    {
        //Attributes of a card include its rank (Ace, queen, etc.) and its suit (Spades, hearts, etc.)
        public string Rank { get; set; }
        public string Suit { get; set; }
        
        //Constructor that specifies exact card
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        //To have a string representation for the object, overrode the method to read better for the user
        //Would otherwise just be "NoLimitTexasHoldem.Card"
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}