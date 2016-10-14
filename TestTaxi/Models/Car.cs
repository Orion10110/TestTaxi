using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaxi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Bramd { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Place { get; set; }
        public string GosNumbet { get; set; }
        public string Stars { get; set; }
        public bool? Active { get; set; }

        public Car()
        {
            this.Orders = new HashSet<Order>();
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
