using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Статус")]
        public Status status { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Дата заказа")]
        public DateTime DateOrder { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? ClientID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? DriverID { get; set; }
        [Display(Name = "Клиент")]
        public virtual Client Client { get; set; }
        [Display(Name = "Водитель")]
        public virtual Driver Driver { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? StreetFromID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? StreetToID { get; set; }
        [Display(Name = "Улица от")]
        public virtual Street StreetFrom { get; set; }
        [Display(Name = "Улица куда")]
        public virtual Street StreetTo { get; set; }
        [Display(Name = "Начальное значение")]
        public int? StartValue { get; set; }
        [Display(Name = "Конечное значение")]
        public int? EndValue { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ApplicationUserID { get; set; }
    }
}
