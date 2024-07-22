using System.ComponentModel.DataAnnotations;          //To use [Key]
using System.ComponentModel.DataAnnotations.Schema;   //To use [ForeignKey()]

namespace NoLimitTexasHoldemV2.Models
{
    public class Card
    {
        
        //Attributes/columns in Card table, keep in mind PK's, FK's, and nullables
        [Key]
        public int CardId { get; set; }
        public string Rank { get; set; }
        public string Suit { get; set; }

        [ForeignKey("PlayerHandData")]
        public int? PlayerHandDataId { get; set; }
        public HandData PlayerHandData { get; set; }

        [ForeignKey("MachineHandData")]
        public int? MachineHandDataId { get; set; }
        public HandData MachineHandData { get; set; }

        [ForeignKey("CommunityHandData")]
        public int? CommunityHandDataId { get; set; }
        public HandData CommunityHandData { get; set; }
        
        //Constructor that specifies exact card
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        //To have a string representation for the object, overrode the method to read better for the user
        //Would otherwise just be "NoLimitTexasHoldem.Card"
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}