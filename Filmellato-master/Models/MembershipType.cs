using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmellato.Models
{
    public class MembershipType
    {
        //Byte >> we have 4 different membership types
        public byte Id { get; set; }
        public string MembershipName { get; set; }

        //Short >> biggest number is 300
        public short SignUpFee { get; set; }

        //Byte >> biggest number is 12
        public byte Duration { get; set; }

        //Byte >> number between 0 and 100
        public byte DiscountRate { get; set; }

        //These are used in the Min18YearsIfAMember validation class to avoid magic numbers
        //They are in the PopulateMembershipTypes migration >> put to the databsase, these are IDs
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}