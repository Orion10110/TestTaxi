namespace TestTaxi.Models
{
    public class ValueTaximeter
    {
        public int Id { get; set; }
        public int? StartValue { get; set; }
        public int? EndValue { get; set; }
        public virtual Order Order { get; set; }
    }
}