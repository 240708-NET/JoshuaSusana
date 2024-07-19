using NoLimitTexasHoldemV2.Models;      //To use HandData.cs

namespace NoLimitTexasHoldemV2.Data
{
    public class HandRepository : IHandRepository
    {
        public string _path = "";

        public HandRepository(string Path)
        {
            _path = Path;
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
        }

        public void ReadHandHistory()
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

        public void DeleteAllHandHistory()
        {
            //Clear the file by writing an empty string into it
            File.WriteAllText(_path, string.Empty);
        }
    }
}