using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Filmellato.Models;

namespace Filmellato.ViewModels
{
    public class CustomerFormViewModel
    {
        /* No List, IEnumerable >> we do not need any functionality
        provided by the List class (add / remove / access an object by index),
        all we need is a way to iterate over the MembershipTypes
        
        If later we will replace List with another collection (like Array),
        we do not have to come back here to modify this ViewModel as long
        as that collection implement IEnumerable*/
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        /*Customer, or copy and paste their propertyes >>
        now we will use the Customer entity, because we want to
        use them later, and we do not need new properties,
        but in case we need new properties required by the view, we should
        separate the domain and view models*/
        public Customer Customer { get; set; }

        //NEW
        public string ImagePath { get; set; }

        //Set the title on the CustomerForm view
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return "Ügyfél adatainak módosítása";
                }
                else
                {
                    return "Ügyfél hozzáadása";
                }
            }
        }
    }
}
