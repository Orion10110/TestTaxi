using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? BrandId { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? TypeCarId { get; set; }
        [Display(Name = "Мест")]
        public int? Place { get; set; }
        [Display(Name = "Гос номер")]
        public string GosNumbet { get; set; }
        [Display(Name = "Комфорт")]
        public string Stars { get; set; }
        [Display(Name = "Активна")]
        public bool? Active { get; set; }

        public Car()
        {
            this.Drivers = new HashSet<Driver>();
        }

        public virtual ICollection<Driver> Drivers { get; set; }
        [Display(Name = "Марка")]
        public virtual Brand Brand { get; set; }
        [Display(Name = "Тип")]
        public virtual TypeCar TypeCar { get; set; }
    }
}
