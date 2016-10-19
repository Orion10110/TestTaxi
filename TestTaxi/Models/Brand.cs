using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class Brand
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Марка")]
        public string Name { get; set; }

        public Brand()
        {
            this.Cars = new HashSet<Car>();
        }

        public virtual ICollection<Car> Cars { get; set; }
    }
}