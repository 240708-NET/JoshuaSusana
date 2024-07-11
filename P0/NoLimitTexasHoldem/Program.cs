namespace NoLimitTexasHoldem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a new deck
            Deck deck = new Deck();

            deck.Shuffle();

            //Dealing hole cards to player and machine
            Card playerCard1 = deck.Deal();
            Card machineCard1 = deck.Deal();
            Card playerCard2 = deck.Deal();
            Card machineCard2 = deck.Deal();

            //Outputting what the player and machine's hole cards are
            Console.WriteLine($"Player has {playerCard1} and {playerCard2}");
            Console.WriteLine($"Machine has {machineCard1} and {machineCard2}");

            //Dealing flop, turn, and river in way it would be done in real life
            Card burnCard1 = deck.Deal();
            Card communityCard1 = deck.Deal();
            Card communityCard2 = deck.Deal();
            Card communityCard3 = deck.Deal();
            Card burnCard2 = deck.Deal();
            Card communityCard4 = deck.Deal();
            Card burnCard3 = deck.Deal();
            Card communityCard5 = deck.Deal();

            Console.WriteLine($"The community cards are \n {communityCard1} \n {communityCard2} \n {communityCard3} \n {communityCard4} \n {communityCard5}");
        }
    }
}