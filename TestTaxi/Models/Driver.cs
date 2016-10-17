using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class Driver
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }
        [Display(Name = "Фамилия")]
        public string Patronymic { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Дата приступления к работе")]
        public DateTime DateOfEmployment { get; set; }
        [Display(Name = "Автомобиль")]
        public virtual Car Car { get; set; }
        [Display(Name = "Категория")]
        public int? Category { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? CarID { get; set; }
        public Driver()
        {
            this.Orders = new HashSet<Order>();
            this.Districts = new HashSet<District>();
        }

       
        public virtual ICollection<District> Districts {get;set;}
        public virtual ICollection<Order> Orders { get; set; }

    }
}