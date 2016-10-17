using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaxi.Models
{
    public class LocationOrder
    {
        [Key]
        [ForeignKey("Order")]
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
          public virtual Order Order { get; set; }
    }
}