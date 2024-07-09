class Program
{
	static void Main(string[]args)
	{
		Console.WriteLine("\nLet's play Rock Paper Scissors!\n");

		//Variables
		string userChoice;
		string machineChoice;
		string[] choices = {"rock", "paper", "scissors"};

		//Generating a choice for the machine randomly
		Random rand = new Random();
		int machineChoiceIndex = rand.Next(0,3);
		machineChoice = choices[machineChoiceIndex];

		//Getting user input
		Console.Write("Enter rock, paper, or scissors: ");
		userChoice = Console.ReadLine().ToLower().Trim();		
		//For above line, ToLower() converts input to all lower case, and Trim() gets rid of trailing or leading whitespace

		//Telling the user what the machine's choice is
		Console.WriteLine("\nThe machine chose " + machineChoice);
		
		//All 9 possible outcomes
		if(userChoice == "rock")
		{
			if(machineChoice == "rock")
			{
				Console.WriteLine("It's a draw.");	
			}
			else if(machineChoice == "paper")
			{
				Console.WriteLine("Sorry, you lose...");
			}
			else
			{
				Console.WriteLine("Congratulations, you win!");
			}
		}
		else if(userChoice == "paper")
		{
			if(machineChoice == "rock")
                        {
				Console.WriteLine("Congratulations, you win!");
                        }
                        else if(machineChoice == "paper")
                        {
				 Console.WriteLine("It's a draw.");
                        }
                        else
                        {
				 Console.WriteLine("Sorry, you lose...");
                        }

		}
		else if(userChoice == "scissors")
		{
			if(machineChoice == "rock")
                        {
				Console.WriteLine("Sorry, you lose...");
                        }
                        else if(machineChoice == "paper")
                        {
				Console.WriteLine("Congratulations, you win!");
                        }
                        else
                        {
				Console.WriteLine("It's a draw.");
                        }

		}
		//If user input does not make sense even after input validation
		else
		{
			Console.WriteLine("Your input was invalid");
		}
	}	
}
