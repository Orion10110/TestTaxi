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
        public int? BrandId { get; set; }
        public string Name { get; set; }
        public int? TypeCarId { get; set; }
        public int? Place { get; set; }
        public string GosNumbet { get; set; }
        public string Stars { get; set; }
        public bool? Active { get; set; }

        public Car()
        {
            this.Drivers = new HashSet<Driver>();
        }

        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual TypeCar TypeCar { get; set; }
    }
}
