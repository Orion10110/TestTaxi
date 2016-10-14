using System;
using System.Collections.Generic;

namespace TestTaxi.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int? Category { get; set; }
        public string GosNumber { get; set; }
        public Driver()
        {
            this.Orders = new HashSet<Order>();
            this.Districts = new HashSet<District>();
        }



        public virtual ICollection<District> Districts {get;set;}
        public virtual ICollection<Order> Orders { get; set; }

    }
}