using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaxi.Models
{
    public class TypeCar
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public TypeCar()
        {
            this.Cars = new HashSet<Car>();
        }

        public virtual ICollection<Car> Cars { get; set; }
    }
}