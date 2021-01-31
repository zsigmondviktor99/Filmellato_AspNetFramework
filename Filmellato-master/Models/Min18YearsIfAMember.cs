using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Filmellato.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //This gives us access to the containing class (now Customer)
            //This is an object >> cast it to a Customer
            var customer = (Customer)validationContext.ObjectInstance;

            //PayAsYouGo
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                //Validation success
                return ValidationResult.Success;

            //Not a PayAsYouGo and empty BirthDate field 
            if (customer.BirthDate == null)
                //Validation error
                return new ValidationResult("Birthdate is required.");

            //Not a PayAsYouGo and under 18
            //BirthDate .VALUE >> because BirthDate is nullable
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}
