using System.Collections.Generic;       //To be able to use lists
using System.Linq;                      //So I can use GroupBy, OrderBy, etc.

namespace NoLimitTexasHoldem
{
    public class HandEvaluator
    {
        public HandRank EvaluateHand(List<Card> hand)
        {
            //Groups by rank (Ace, queen, etc.), then puts in descending order by number of cards in each group, 
            //then puts in descending order by rank, then converts to a list
            var groupedByRank = hand.GroupBy(card => card.Rank)
                                    .OrderByDescending(group => group.Count())
                                    .ThenByDescending(group => group.Key)
                                    .ToList();

            //Groups by suit (Spades, hearts, etc.), the puts in descending order by number of cards in each group
            //the converts to a list
            var groupedBySuit = hand.GroupBy(card => card.Suit)
                                    .OrderByDescending(group => group.Count())
                                    .ToList();

            //Checking for One Pair
            if (groupedByRank[0].Count() == 2)
            {
                return HandRank.OnePair;
            }
            
            //If we reach here, then must be high card
            return HandRank.HighCard;
        }
    }
}