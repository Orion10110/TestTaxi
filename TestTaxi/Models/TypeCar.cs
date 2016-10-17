using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class TypeCar
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Тип машины")]
        public string Type { get; set; }

        public TypeCar()
        {
            this.Cars = new HashSet<Car>();
        }

        public virtual ICollection<Car> Cars { get; set; }
    }
}