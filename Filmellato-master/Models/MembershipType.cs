using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmellato.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string MembershipName { get; set; }

        public short SignUpFee { get; set; }

        public byte Duration { get; set; }

        public byte DiscountRate { get; set; }

        //Ezek a Min18YearsIfAMember validacios osztalyban vannak hasznalatban
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}