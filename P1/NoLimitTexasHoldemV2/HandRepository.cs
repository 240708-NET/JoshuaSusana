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
    }
}