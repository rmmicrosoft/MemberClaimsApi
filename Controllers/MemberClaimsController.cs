using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberClaimsApi.Models;
using MemberClaimsApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MemberClaimsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberClaimsController : ControllerBase
    {
        private readonly ILogger<MemberClaimsController> _logger;
        private IMemberClaimService _mcService;
        public MemberClaimsController(ILogger<MemberClaimsController> logger, IMemberClaimService mcService)
        {
            _logger = logger;
            _mcService = mcService;
        }


        [HttpGet("GetAllMemeberClaims")]        
        public string GetAllMemeberClaims()
        {           
            var members = _mcService.GetMembers();
            var claims = _mcService.GetClaims();
            var result = from d in members
                         join e in claims on d.MemberID equals e.MemberID into memDept
                         select new
                         {
                             MemberName = d.FirstName + ", " + d.LastName,
                             Claims = from mem2 in memDept
                                      orderby mem2.ClaimDate
                                      select new { Date = mem2.ClaimDate, Amount = mem2.ClaimAmount }
                         };
            return JsonConvert.SerializeObject(result);

        }

        [HttpGet("GetMemeberClaimsByClaimDate")]
        public string GetMemeberClaims(string claimDate)
        {
            DateTime dtClaim = Convert.ToDateTime(claimDate);
            var members = _mcService.GetMembers();
            var claims = _mcService.GetClaims();           
            var result = from d in members
                         join e in claims.Where(x=>x.ClaimDate == dtClaim) on d.MemberID equals e.MemberID into memDept                         
                         select new
                         {
                             MemberName = d.FirstName + ", " + d.LastName,
                             Claims = from mem2 in memDept
                                      orderby mem2.ClaimDate
                                      select new { Date = mem2.ClaimDate, Amount = mem2.ClaimAmount }
                         };
            return JsonConvert.SerializeObject(result);

        }

    }
}
