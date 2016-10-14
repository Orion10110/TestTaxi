using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaxi.Models
{
    public class Client
    {
        public Client()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }

        public int? DiscountID { get; set; }
        public virtual Discount Discount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
