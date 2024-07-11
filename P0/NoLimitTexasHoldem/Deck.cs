using System;                           //For the random class and lists

namespace NoLimitTexasHoldem
{
    public class Deck
    {
        //Attributes of a deck include the cards and a random object to be able to shuffle
        private List<Card> cards;
        private Random random;

        public Deck()
        {
            //Instantiating a List object that holds Card objects
            cards = new List<Card>();

            //Note that these are in the constructor instead of with the other attributes since I do not expect the arrays to be
            //needed anywhere else but in initialization
            string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            //For each card that exists in a standard deck of playing cards, add it to the deck
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }

            //Instantiating a Random object
            random = new Random();
        }

        public void Shuffle()
        {
            for(int i=0; i<52; i++)
            {
                //Generate a random number between 0 and i+1 (Including 0 and exclusing i+1)
                int j = random.Next(i + 1); 
                //Using temp method to swap cards an indices i and j
                Card temp = cards[i];       
                cards[i] = cards[j];
                cards[j] = temp;

                //This uses the Fisher-Yates Shuffle, one of the first things that came up for me in my online lookups
            }
        }

        public Card Deal()
        {
            //Cannot deal an empty deck of cards
            if (cards.Count == 0)
            {
                 return null;
            }
            //Actually get the card before removing so we can return it
            Card card = cards[0];

            //We can always remove at indice 0 since a List always shifts everything to the left and dynamically resizes
            cards.RemoveAt(0);
            return card;
        }
    }
}