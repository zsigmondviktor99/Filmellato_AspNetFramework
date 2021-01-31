using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmellato.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        
        public string Name { get; set; }
        
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        public bool IsBlocked { get; set; }

        //Navigation property >> navigate us to a new type
        //Customer >> to its MembershipType
        public MembershipType MembershipType { get; set; }

        //Entity recognise this as a foreign key
        [Required(ErrorMessage = "Please select a membership type.")]
        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "Please enter customer's E-mail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter customer's phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter customer's address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter customer's identity card number.")]
        public string IdentityCard { get; set; }

        public int NumberOfCurrentlyRentedMovies { get; set; }

        //NEW
        public string ImagePath { get; set; }

        public Customer()
        {
            BirthDate = DateTime.Parse("1900-01-01");
            NumberOfCurrentlyRentedMovies = 0;
        }
    }
}
