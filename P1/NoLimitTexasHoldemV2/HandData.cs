namespace NoLimitTexasHoldemV2.Data
{
    //Created a class that has all the attributes/information involving a hand
    public class HandData
    {
        public DateTime HandDateTime { get; set; }
        public int PlayerInitialStack { get; set; }
        public int MachineInitialStack { get; set; }
        public int Bet { get; set; }
        public List<Card> PlayerHoleCards { get; set; }
        public List<Card> MachineHoleCards { get; set; }
        public List<Card> CommunityCards { get; set; }
        public HandRank PlayerHandRank { get; set; }
        public HandRank MachineHandRank { get; set; }
        public string Outcome { get; set; } = "";

        //Will use this when putting in the text file for each hand
        public override string ToString()
        {
            return $"Date and Time: {HandDateTime}\n" +
                   $"Player's Initial Stack: {PlayerInitialStack}\n" +
                   $"Machine's Initial Stack: {MachineInitialStack}\n" +
                   $"Bet: {Bet}\n" +
                   $"Player Hole Cards: {string.Join(", ", PlayerHoleCards)}\n" +
                   $"Machine Hole Cards: {string.Join(", ", MachineHoleCards)}\n" +
                   $"Community Cards: {string.Join(", ", CommunityCards)}\n" +
                   $"Player Hand Rank: {PlayerHandRank}\n" +
                   $"Machine Hand Rank: {MachineHandRank}\n" +
                   $"Outcome: {Outcome}\n";
        }
    }
}