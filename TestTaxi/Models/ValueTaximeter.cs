using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class ValueTaximeter
    {
        [Key]
        [ForeignKey("Order")]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Начальное значение")]
        public int? StartValue { get; set; }
        [Display(Name = "Конечное значение")]
        public int? EndValue { get; set; }
        [Display(Name = "Заказ")]
        public virtual Order Order { get; set; }
    }
}