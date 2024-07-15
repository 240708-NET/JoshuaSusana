using System;       //To be able to use lists, GroupBy, and throw exceptions

namespace NoLimitTexasHoldemV2
{
    public class HandEvaluator
    {
        public HandRank EvaluateHand(List<Card> hand, out List<int> highCards)
        {
            //Groups by rank (Ace, queen, etc.), then puts in descending order by number of cards in each group, 
            //then puts groups in descending order by rank, then converts to a list
            var groupedByRank = hand.GroupBy(card => card.Rank)
                                    .OrderByDescending(group => group.Count())
                                    .ThenByDescending(group => group.Key)
                                    .ToList();

            //Groups by suit (Spades, hearts, etc.), then puts in descending order by number of cards in each group
            //the converts to a list
            var groupedBySuit = hand.GroupBy(card => card.Suit)
                                    .OrderByDescending(group => group.Count())
                                    .ToList();
            
            //For both above, end data type is List<IGrouping<int, Card>>

            //Creating a list of high cards to help deal with tiebreakers
            highCards = new List<int>();

            //Checking for straight flush
            if (IsStraightFlush(hand))
            {
                return HandRank.StraightFlush;
            }

            //Checking for Quads
            if (groupedByRank[0].Count() == 4)
            {
                return HandRank.Quads;
            }

            //Checking for Full House
            if (groupedByRank[0].Count() == 3 && groupedByRank[1].Count() == 2)
            {
                return HandRank.FullHouse;
            }

            //Checking for Flush
            if (groupedBySuit[0].Count() >= 5)
            {
                return HandRank.Flush;
            }
            
            //Checking for Straight
            if (IsStraight(hand))
            {
                return HandRank.Straight;
            }

            //Checking for Trips
            if (groupedByRank[0].Count() == 3)
            {
                return HandRank.Trips;
            }

            //Checking for Two Pair
            if (groupedByRank[0].Count() == 2 && groupedByRank[1].Count() == 2)
            {
                return HandRank.TwoPair;
            }
            
            //Checking for One Pair
            if (groupedByRank[0].Count() == 2)
            {
                //Convert each card in 1st group to integer, then adds results to highCards list
                highCards.AddRange(groupedByRank[0].Select(card => RankToInt(card.Rank)));
                //Skip the pair that we already added, convert the remaining groups/cards into integers,
                //flatten into one sequence, put into descending order, then add to highCards list
                highCards.AddRange(groupedByRank.Skip(1)
                         .SelectMany(group => group.Select(card => RankToInt(card.Rank)))
                         .OrderByDescending(rank => rank));
                return HandRank.OnePair;
            }
            
            //If we reach here, then must be high card
            //Taking the cards grouped by rank, converting them to integers, then flattening them into one sequence, then
            //putting them into descending order, then converting to a list
            highCards = groupedByRank.SelectMany(group => group.Select(card => RankToInt(card.Rank)))
                                     .OrderByDescending(rank => rank)
                                     .ToList();
            return HandRank.HighCard;

            //Keep in mind don't use else if since return keyword exits the method anyway
        }
        //Method to convert card rankings to an int system
        public int RankToInt(string rank)
        {
            if(rank == "2") return 2;
            else if(rank == "3") return 3;
            else if(rank == "4") return 4;
            else if(rank == "5") return 5;
            else if(rank == "6") return 6;
            else if(rank == "7") return 7;
            else if(rank == "8") return 8;
            else if(rank == "9") return 9;
            else if(rank == "10") return 10;
            else if(rank == "J") return 11;
            else if(rank == "Q") return 12;
            else if(rank == "K") return 13;
            else if(rank == "A") return 14;
            else throw new ArgumentException("Invalid card rank");
        }

        //Created a method to check for straight so that above looks neater, more "methodical"
        public bool IsStraight(List<Card> hand)
        {
            //Transforms each card object into just the rank attribute, then removes duplicates, then converts to int, 
            //then sorts in ascending order, then converts to a lsit
            var orderedByRank = hand.Select(card => card.Rank)
                                   .Distinct()
                                   .Select(RankToInt)
                                   .OrderBy(rank => rank)
                                   .ToList();

            //Since already ordered numerically and removes duplicates, if first element of list plus 4 equals the 5th
            //element of the list, then we have a straight
            for (int i = 0; i <= orderedByRank.Count - 5; i++)
            {
                if (orderedByRank[i] + 4 == orderedByRank[i + 4])
                {
                    return true;
                }
            }
            //We have a special if-statement for a low straight since A=14 in my ranked int system
            if (orderedByRank.Contains(14) && orderedByRank.Contains(2) &&
                orderedByRank.Contains(3) && orderedByRank.Contains(4) &&
                orderedByRank.Contains(5))
            {
                return true;
            }
            return false;
        }

        //Created a method to check for straight flush so that above looks neater, more "methodical"
        public bool IsStraightFlush(List<Card> hand)
        {
            //Grouping by suit, discarding groups with < 5 since a straight flush needs at least a flush first, 
            //then converting to a list
            var groupedBySuit = hand.GroupBy(card => card.Suit)
                                    .Where(group => group.Count() >= 5)
                                    .ToList();

            //For each group in the list, if it passes the IsStraight test, then the hand is a straight flush
            foreach (var group in groupedBySuit)
            {
                if (IsStraight(group.ToList()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}