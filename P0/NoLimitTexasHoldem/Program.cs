using System.Runtime.InteropServices;

namespace NoLimitTexasHoldem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring and initializing all player stacks
            int playerstack = 10;
            int machinestack = 10;
            int playerbet;

            //Instantiating a new deck
            Deck deck = new Deck();

            //Instantiating a HandEvaluator object
            HandEvaluator handevaluator = new HandEvaluator();

            while(true)
            {
                //At start of every hand, clear window and output player stacks
                Console.Clear();
                Console.WriteLine($"Player stack: {playerstack}");
                Console.WriteLine($"Machine stack: {machinestack}");
                
                //Initialize and shuffle deck at start of each hand
                deck.InitializeDeck();
                deck.Shuffle();

                //Dealing hole cards to player and machine
                Card playerCard1 = deck.Deal();
                Card machineCard1 = deck.Deal();
                Card playerCard2 = deck.Deal();
                Card machineCard2 = deck.Deal();

                //Outputting what the player and machine's hole cards are
                Console.WriteLine($"You have {playerCard1} and {playerCard2}");

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

                Console.WriteLine("Enter your bet (at least 1, whole numbers only):");
                //While loop is input validation
                while (!int.TryParse(Console.ReadLine(), out playerbet) || playerbet < 1 || playerbet > playerstack)
                {
                    Console.WriteLine("Invalid bet. Enter a value between 1 and your current stack.");
                }

                playerstack -= playerbet;
                machinestack -= playerbet;
                
                //Combining hole cards with community cards for both players
                List<Card> playerHand = new List<Card> { playerCard1, playerCard2, communityCard1, communityCard2, communityCard3, communityCard4, communityCard5 };
                List<Card> machineHand = new List<Card> { machineCard1, machineCard2, communityCard1, communityCard2, communityCard3, communityCard4, communityCard5 };

                //Evaluating each player's hand
                HandRank playerHandRank = handevaluator.EvaluateHand(playerHand);
                HandRank machineHandRank = handevaluator.EvaluateHand(machineHand);

                //Outputting machine's hole cards
                Console.WriteLine($"Machine has {machineCard1} and {machineCard2}");

                //Outputting hand ranks
                Console.WriteLine($"Player has {playerHandRank}");
                Console.WriteLine($"Machine has {machineHandRank}");
            
                //Since enums are assigned integers, and I implemented HandRank as an enum, these conditional statements work
                if (playerHandRank > machineHandRank)
                {
                    Console.WriteLine("You win the hand!");
                    playerstack += playerbet * 2;
                }
                else if (machineHandRank > playerHandRank)
                {
                    Console.WriteLine("Sorry, you lose the hand.");
                    machinestack += playerbet * 2;
                }
                else
                {
                    Console.WriteLine("Chop it up.");
                    playerstack += playerbet;
                    machinestack += playerbet;
                }

                //If either player busts, the game is over
                if (playerstack <= 0)
                {
                    Console.WriteLine("You busted! Game over.");
                    break;
                }
                if (machinestack <= 0)
                {
                    Console.WriteLine("Machine busted! You win!!!");
                    break;
                }

                // Wait for player to hit enter to proceed to the next hand
                Console.WriteLine("Press Enter to continue to the next hand...");
                Console.ReadLine();
            }
        }
    }
}