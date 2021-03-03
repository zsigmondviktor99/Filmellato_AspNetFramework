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

        [Required(ErrorMessage = "Kérem adja meg az ügyfél nevét!")]
        [StringLength(255)]
        
        public string Name { get; set; }
        
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        public bool IsBlocked { get; set; }

        //Navigacios tulajdonsag >> atnavigal minket a masik tipusra (Ugyfel >> Ugyfel tagsaga)
        public MembershipType MembershipType { get; set; }

        //Entity ez alapjan kesziti el az idegen kulcsot
        [Required(ErrorMessage = "Kérem adja meg a tagság típusát!")]
        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "Kérem adja meg az ügyfél e-mail címét!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kérem adja meg az ügyfél telefonszámát!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Kérem adja meg az ügyfél lakcímét!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Kérem adja meg az ügyfél SZIG számát!")]
        public string IdentityCard { get; set; }

        public int NumberOfCurrentlyRentedMovies { get; set; }

        public string ImagePath { get; set; }

        public Customer()
        {
            BirthDate = DateTime.Parse("1900-01-01");
            NumberOfCurrentlyRentedMovies = 0;
        }
    }
}
