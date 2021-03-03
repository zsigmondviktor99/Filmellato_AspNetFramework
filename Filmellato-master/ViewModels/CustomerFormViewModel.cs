using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Filmellato.Models;

namespace Filmellato.ViewModels
{
    public class CustomerFormViewModel
    {
        //IEnumerable >> nincs szuksegunk a listak nyujtotta funkcionalitasra
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }

        public string ImagePath { get; set; }

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
