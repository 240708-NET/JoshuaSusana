class Game
{
    // Fields
    Random rand = new Random();
    int targetNumber;
    int guessNumber = -1;
    int roundCount = 0;
    public string guessString { get; set; } = ""; // auto-property

    public Game()
    {
        targetNumber = rand.Next(11);
    } 

    public int PlayGame ()
    {
        roundCount = 0;
        do 
        {
            //roundCount = roundCount + 1;
            //roundCount += 1;
            roundCount++;

            Console.Write( "Please enter a guess between -1 and 11: " );
            guessString = Console.ReadLine();

            guessNumber = Int32.Parse( guessString );

            if( guessNumber == targetNumber )
            {
                Console.WriteLine( "Hey, Nice Job!" );
            }

            else if( guessNumber > targetNumber )
            {
                Console.WriteLine( "Oops, too high!" );
            }

            else 
            {
                Console.WriteLine( "Oops, too low!" );
            }
        } while ( guessNumber != targetNumber );
        return roundCount;
    }
}