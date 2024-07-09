class Program
{
	static void Main(string[]args)
	{
		//Declaring Variables
		int targetNumber;
		int guessNumber;
		int roundCount;
		string guessString;

		roundCount = 0;

		Random rand = new Random();
		targetNumber = rand.Next(11);

		do {
			roundCount++;			

			Console.Write("Please enter a guess between -1 and 11: ");
			guessString = Console.ReadLine();

			guessNumber = Int32.Parse(guessString);

			if(guessNumber == targetNumber)
			{
				Console.WriteLine("Congratulations! You Win!");
			}
			else if(guessNumber > targetNumber)
			{
				Console.WriteLine("Your guess was higher than the target number.");
			}
			else
			{
				Console.WriteLine("Your guess was lower than the target number.");
			}
		} while(guessNumber != targetNumber);
		Console.WriteLine("Thanks for playing!");
		Console.WriteLine("It took you {0} rounds to guess the number.", roundCount);
	}
}
