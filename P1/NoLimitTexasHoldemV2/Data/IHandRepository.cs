using NoLimitTexasHoldemV2.Models;      //To use HandData.cs

namespace NoLimitTexasHoldemV2.Data
{
    public interface IHandRepository
    {
        //Contract includes Create, Read, and Delete rules
        //Not sure yet how to implement Update in a way that feels practical
        void SaveHandData(HandData handData);
        void ReadHandHistory();
        void DeleteAllHandHistory();
    }
}