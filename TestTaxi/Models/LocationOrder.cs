using System;

namespace TestTaxi.Models
{
    public class LocationOrder
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateComeFrom { get; set;}
        public DateTime DateComeIn { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        
        public int? StreetFromID { get; set; }
        public int? StreetToID { get; set; }

        public virtual Street StreetFrom { get; set; }
        public virtual Street StreetTo { get; set; }

    }
}