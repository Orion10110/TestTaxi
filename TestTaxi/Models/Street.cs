using System.Collections.Generic;

namespace TestTaxi.Models
{
    public class Street
    {
        public Street()
        {
            this.LocationOrders = new HashSet<LocationOrder>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int? DistrictID { get; set; }
        public virtual District  District { get; set;}

        public virtual ICollection<LocationOrder> LocationOrders { get; set; } 
    }
}