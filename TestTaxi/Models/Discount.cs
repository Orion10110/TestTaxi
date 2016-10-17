using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestTaxi.Models
{
    public class Discount
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public int Name { get; set; }
        [Display(Name = "Процент")]
        public int Percent { get; set; }



        public Discount()
        {
            this.Clients = new HashSet<Client>();
        }

        public virtual ICollection<Client> Clients { get; set; }
    }
}