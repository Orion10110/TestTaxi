using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaxi.Models
{
    public class ValueTaximeter
    {
        [Key]
        [ForeignKey("Order")]
        public int Id { get; set; }
        public int? StartValue { get; set; }
        public int? EndValue { get; set; }
        public virtual Order Order { get; set; }
    }
}