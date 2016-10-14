using System.Collections.Generic;

namespace TestTaxi.Models
{
    public class District
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public District()
        {
            this.Drivers = new HashSet<Driver>();
            this.Streets = new HashSet<Street>();

        }

        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Street> Streets { get; set; }

    }
}