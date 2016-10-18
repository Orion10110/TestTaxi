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
        [Display(Name = "Значение таксометра")]
        public virtual ValueTaximeter ValueTaximeter { get; set; }
        [Display(Name = "Данные поездки")]
        public virtual LocationOrder LocationOrder { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? ClientID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? DriverID { get; set; }
        [Display(Name = "Клиент")]
        public virtual Client Client { get; set; }
        [Display(Name = "Водитель")]
        public virtual Driver Driver { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ApplicationUserID { get; set; }
    }
}
