using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaxi.Models
{
    public class Order
    {
        public int Id { get; set; }
       
        public Status status { get; set; }

        public virtual ValueTaximeter ValueTaximeter { get; set; }
        public virtual LocationOrder LocationOrder { get; set; }

        public int? ClientID { get; set; }
        public int? DriverID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Driver Driver { get; set; }
      

        public string ApplicationUserID { get; set; }
    }
}
