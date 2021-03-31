using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberClaimsApi.Models
{
    public class Claim
    {
        //MemberID ClaimDate   ClaimAmount

        public int MemberID { get; set; }

        public DateTime ClaimDate { get; set; }

        public double ClaimAmount { get; set; }


    }
}
