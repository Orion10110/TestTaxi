using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class LocationOrder
    {
        [Key]
        [ForeignKey("Order")]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Дата заказа")]
        public DateTime DateOrder { get; set; }
        [Display(Name = "Время прибытия  клиенту")]
        public DateTime DateComeFrom { get; set;}
        [Display(Name = "Время приезда к пункту")]
        public DateTime DateComeIn { get; set; }
        [Display(Name = "Место отбытия")]
        public string AddressFrom { get; set; }
        [Display(Name = "Место назначения")]
        public string AddressTo { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? StreetFromID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? StreetToID { get; set; }
        [Display(Name = "Улица от")]
        public virtual Street StreetFrom { get; set; }
        [Display(Name = "Улица куда")]
        public virtual Street StreetTo { get; set; }
        [Display(Name = "ЗаказЫ")]
        public virtual Order Order { get; set; }
    }
}