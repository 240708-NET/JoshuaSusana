using NoLimitTexasHoldemV2.Models;      //To use HandData.cs
using Microsoft.EntityFrameworkCore;    //To use things like DbContext
using System.Text.Json;

namespace NoLimitTexasHoldemV2.Data
{
    public class HandRepository : IHandRepository
    {
        //Attributes
        public string _path = "";
        public string connectionString = "";
        //One shared PokerContext instance across all instances of HandRepository.
        static PokerContext context;
        
        //Constructor is paramaterized so that I can differentiate whether I am doing the Repository pattern version
        //or the Entity Framework version. 1 is Repository Pattern, 2 is Entity Framework
        public HandRepository(string PathOrSC, int Version)
        {
            if(Version == 1)
            {
                //Simply set file path
                _path = PathOrSC;
            }

            else if(Version == 2)
            {
                //Set connection string
                connectionString = PathOrSC;
                //Configure DbContext options to use SQL server with the connection string. The .Options part 
                //finalizes the configuration and returns a DbContextOptions<PokerContext> object.
                DbContextOptions<PokerContext> options;
                options = new DbContextOptionsBuilder<PokerContext>()
                    .UseSqlServer(connectionString)
                    .Options;
                //Set context to be a PokerContext object using options
                context = new PokerContext(options);
            }
        }

        public void SaveHandData(HandData handData)
        {
            List<HandData> handDataList = new List<HandData>();
            if (File.Exists(_path))
            {
                var existingData = File.ReadAllText(_path);
                handDataList = JsonSerializer.Deserialize<List<HandData>>(existingData);
            }

            handDataList.Add(handData);

            var jsonData = JsonSerializer.Serialize(handDataList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, jsonData);

            //Entity framework version, simply add to context then save to database
            context.Hands.Add(handData);
            context.SaveChanges();
        }

        public void ReadHandHistoryRepository()
        {
            //If file doesn't exist/cannot be found...
            if (!File.Exists(_path))
            {
                Console.WriteLine("Hand history file does not exist or could not be found.");
                return;
            }
            
            //Read the JSON data from the file
            var jsonData = File.ReadAllText(_path);
            var handDataList = JsonSerializer.Deserialize<List<HandData>>(jsonData);

            //Check if deserialization returned null
            if (handDataList == null || handDataList.Count == 0)
            {
                Console.WriteLine("No hand history found.");
                return;
            }   

            // Print each hand's details to the console
            foreach (var handData in handDataList)
            {
                Console.WriteLine($"Date and Time: {handData.HandDateTime}");
                Console.WriteLine($"Player's Initial Stack: {handData.PlayerInitialStack}");
                Console.WriteLine($"Machine's Initial Stack: {handData.MachineInitialStack}");
                Console.WriteLine($"Bet: {handData.Bet}");

                Console.WriteLine("Player Hole Cards: " + string.Join(", ", handData.PlayerHoleCards.Select(card => $"{card.Rank} of {card.Suit}")));
                Console.WriteLine("Machine Hole Cards: " + string.Join(", ", handData.MachineHoleCards.Select(card => $"{card.Rank} of {card.Suit}")));
                Console.WriteLine("Community Cards: " + string.Join(", ", handData.CommunityCards.Select(card => $"{card.Rank} of {card.Suit}")));


                Console.WriteLine($"Player Hand Rank: {handData.PlayerHandRank}");
                Console.WriteLine($"Machine Hand Rank: {handData.MachineHandRank}");
                Console.WriteLine($"Outcome: {handData.Outcome}");
                Console.WriteLine("-------------------------------------------------");
            }
        }

        public void ReadHandHistoryDB()
        {
            //Get all HandData records that include the below entities, then convert to a list
            List<HandData> hands = context.Hands.Include(h => h.PlayerHoleCards)
                                                .Include(h => h.MachineHoleCards)
                                                .Include(h => h.CommunityCards)
                                                .ToList();

            if (hands.Count == 0)
            {
                Console.WriteLine("No hand history found.");
                return;
            }

            foreach (HandData hand in hands)
            {
                Console.WriteLine(hand.ToString());
            }
        }

        public void DeleteAllHandHistory()
        {
            // Clear the JSON file by writing an empty array
            File.WriteAllText(_path, "[]");

            //Get all HandData records, convert to list, remove records from context, then save to DB
            List<HandData> hands = context.Hands.ToList();
            context.Hands.RemoveRange(hands);
            context.SaveChanges();
        }
    }
}