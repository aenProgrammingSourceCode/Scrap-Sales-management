using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class LocalUserViewModels
    {
        public string Email { get; set; }
        public string UserIdentityToken { get; set; }
    }
}