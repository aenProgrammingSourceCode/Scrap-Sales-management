using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class CompanyViewModels
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime CreateDate { get; set; }
        public string IdentityUserToken { get; set; }
    }
}