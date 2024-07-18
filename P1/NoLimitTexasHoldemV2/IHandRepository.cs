namespace NoLimitTexasHoldemV2.Data
{
    public interface IHandRepository
    {
        //Right now, only part of contract we need is saving data from a hand
        void SaveHandData(HandData handData);
    }
}