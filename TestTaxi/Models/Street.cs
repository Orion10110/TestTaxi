using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class Street
    {
        public Street()
        {
            this.Orders = new HashSet<Order>();
        }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? DistrictID { get; set; }
        [Display(Name = "Название")]
        public virtual District  District { get; set;}
        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Order> Orders { get; set; } 
    }
}