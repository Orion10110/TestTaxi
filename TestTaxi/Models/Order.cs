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

        public virtual ValueTaximeter ValueTaximetr { get; set; }
        public virtual LocationOrder LocationOrder { get; set; }

        public int? ClientID { get; set; }
        public int? DriverID { get; set; }
        public int? CarID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Car Car { get; set; }

        public string ApplicationUserID { get; set; }
    }
}
