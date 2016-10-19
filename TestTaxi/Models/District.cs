using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class District
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        public District()
        {
            this.Drivers = new HashSet<Driver>();
            this.Streets = new HashSet<Street>();

        }
        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Driver> Drivers { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Street> Streets { get; set; }

    }
}