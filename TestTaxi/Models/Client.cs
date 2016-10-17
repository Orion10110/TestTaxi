using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class Client
    {
        public Client()
        {
            this.Orders = new HashSet<Order>();
        }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? DiscountID { get; set; }

        [Display(Name = "Скидка")]
        public virtual Discount Discount { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
