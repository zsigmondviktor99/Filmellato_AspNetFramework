using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Filmellato.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Phone number
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        //To get the IdentityCard number during registration
        [Required]
        [StringLength(255)]
        public string IdentityCard { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {   
        //This DbSet represents Customers table in our DB
        public DbSet<Customer> Customers { get; set; }

        //This DbSet represents Movies table in our DB
        public DbSet<Movie> Movies { get; set; }

        //This DbSet represents MembershipTypes table in our DB
        public DbSet<MembershipType> MembershipTypes { get; set; }

        //This DbSet represents Genres table in our DB
        public DbSet<Genre> Genres { get; set; }

        //This DbSet reptresents Rentals table in our DB
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}