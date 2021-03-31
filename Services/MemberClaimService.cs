using CsvHelper;
using CsvHelper.Configuration;
using MemberClaimsApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemberClaimsApi.Services
{
    public class MemberClaimService : IMemberClaimService
    {
        public List<Member> GetMembers()
        {
            List<Member> result;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                IgnoreBlankLines = false,
            };
            using (TextReader fileReader = File.OpenText("Member.csv"))
            {
                var csv = new CsvReader(fileReader, config);                
                csv.Read();
                result = csv.GetRecords<Member>().ToList();
            }
            return result;
        }
        public List<Claim> GetClaims()
        {
            List<Claim> result;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                IgnoreBlankLines = false,
            };
            using (TextReader fileReader = File.OpenText("Claim.csv"))
            {
                var csv = new CsvReader(fileReader, config);
                csv.Read();
                result = csv.GetRecords<Claim>().ToList();
            }
            return result;
        }
    }
}
