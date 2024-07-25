using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting async method...");
        await PerformLongRunningOperation();
        Console.WriteLine("Async method completed.");
    }

    static async Task PerformLongRunningOperation()
    {
        Console.WriteLine("Starting long running operation...");
        await Task.Delay(3000); // Simulates a 3-second delay
        Console.WriteLine("Long running operation completed.");
    }
}