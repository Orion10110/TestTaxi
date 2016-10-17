using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;

namespace TestTaxi.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //ConnectionStringSql2008  DefaultConnection
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<LocationOrder> LocationOrders{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<ValueTaximeter> ValueTaximeters{ get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<TestTaxi.Models.Brand> Brands { get; set; }

        public System.Data.Entity.DbSet<TestTaxi.Models.TypeCar> TypeCars { get; set; }

        public System.Data.Entity.DbSet<TestTaxi.Models.Driver> Drivers { get; set; }
    }
}