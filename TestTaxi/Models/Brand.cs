using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaxi.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand()
        {
            this.Cars = new HashSet<Car>();
        }

        public virtual ICollection<Car> Cars { get; set; }
    }
}