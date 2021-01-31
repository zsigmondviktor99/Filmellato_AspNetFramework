using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Filmellato.Models;
using System.ComponentModel.DataAnnotations;

namespace Filmellato.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]

        public string Name { get; set; }
        
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public bool IsBlocked { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //Entity recognise this as a foreign key
        [Required]
        public byte MembershipTypeId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string IdentityCard { get; set; }

        public int NumberOfCurrentlyRentedMovies { get; set; }

        //NEW
        public string ImagePath { get; set; }
    }
}