class Program
{
	static void Main( string[] args )
	{
		Console.WriteLine( "High/Low Running" );

		// Singleton - you create a single instance of a thing that is referenced throughout the application to complete some functionality.
		// create an instance of the Game class
		Game newGame = new Game(); 

		int roundCount = newGame.PlayGame();

		Console.WriteLine( "Thanks for playing!" );
		Console.WriteLine( "You took {0} rounds to guess the answer!", roundCount );
	}	
}