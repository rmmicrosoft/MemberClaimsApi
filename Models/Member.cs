﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberClaimsApi.Models
{
    public class Member
    {
        //MemberID	EnrollmentDate	FirstName	LastName
        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
