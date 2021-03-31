using MemberClaimsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberClaimsApi.Services
{
    public interface IMemberClaimService
    {
        List<Member> GetMembers();
        List<Claim> GetClaims();
    }
}
