using NoLimitTexasHoldemV2.Models;      //To use HandData.cs
using Microsoft.EntityFrameworkCore;    //To use things like DbContext

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
            //using keyword will automatically close the file and release any resources
            //true parameter opens file in append mode
            //I just separated each hand with a line of hyphens
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine(handData.ToString());
                writer.WriteLine(new string('-', 75));
            }

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

            //Read all lines from the file
            List<string> allLines = File.ReadAllLines(_path).ToList();

            //If text file is empty...
            if (allLines.Count == 0)
            {
                Console.WriteLine("No hand history found.");
                return;
            }
            
            //Outputting to console
            foreach (string line in allLines)
            {
                Console.WriteLine(line);
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
            //Clear the file by writing an empty string into it
            File.WriteAllText(_path, string.Empty);

            //Get all HandData records, convert to list, remove records from context, then save to DB
            List<HandData> hands = context.Hands.ToList();
            context.Hands.RemoveRange(hands);
            context.SaveChanges();
        }
    }
}