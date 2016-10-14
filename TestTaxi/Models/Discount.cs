using System.Collections.Generic;

namespace TestTaxi.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public int Percent { get; set; }

        public Discount()
        {
            this.Clients = new HashSet<Client>();
        }

        public virtual ICollection<Client> Clients { get; set; }
    }
}